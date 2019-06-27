﻿using HMS.Common.GuardToolkit;
using HMS.Common.IdentityToolkit;
using HMS.Entities.Identity;
using HMS.Services.Contracts.Identity;
using HMS.Services.Identity;
using HMS.ViewModels.Identity.Settings;
using HMS.ViewModels.Identity;
using DNTBreadCrumb.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using System;
using DNTCommon.Web.Core;

namespace HMS.Areas.Identity.Controllers
{
    [Authorize]
    [Area(AreaConstants.IdentityArea)]
    [BreadCrumb(Title = "مشخصات کاربری", UseDefaultRouteUrl = true, Order = 0)]
    public class UserProfileController : Controller
    {
        private readonly IProtectionProviderService _protectionProviderService;
        private readonly IApplicationRoleManager _roleManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;
        private readonly IUsedPasswordsService _usedPasswordsService;
        private readonly IApplicationUserManager _userManager;
        private readonly IUsersPhotoService _usersPhotoService;
        private readonly IUserValidator<User> _userValidator;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(
            IApplicationUserManager userManager,
            IApplicationRoleManager roleManager,
            IApplicationSignInManager signInManager,
            IProtectionProviderService protectionProviderService,
            IUserValidator<User> userValidator,
            IUsedPasswordsService usedPasswordsService,
            IUsersPhotoService usersPhotoService,
            IOptionsSnapshot<SiteSettings> siteOptions,
            ILogger<UserProfileController> logger)
        {
            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _roleManager = roleManager;
            _roleManager.CheckArgumentIsNull(nameof(_roleManager));

            _signInManager = signInManager;
            _signInManager.CheckArgumentIsNull(nameof(_signInManager));

            _protectionProviderService = protectionProviderService;
            _protectionProviderService.CheckArgumentIsNull(nameof(_protectionProviderService));

            _userValidator = userValidator;
            _userValidator.CheckArgumentIsNull(nameof(_userValidator));

            _usedPasswordsService = usedPasswordsService;
            _usedPasswordsService.CheckArgumentIsNull(nameof(_usedPasswordsService));

            _usersPhotoService = usersPhotoService;
            _usersPhotoService.CheckArgumentIsNull(nameof(_usersPhotoService));

            _siteOptions = siteOptions;
            _siteOptions.CheckArgumentIsNull(nameof(_siteOptions));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));
        }

        [Authorize(Roles = ConstantRoles.Admin)]
        [BreadCrumb(Title = "ویریش کاربر", Order = 1)]
        public async Task<IActionResult> AdminEdit(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            return await renderForm(user, isAdminEdit: true);
        }

        [BreadCrumb(Title = "اطلاعات کاربر", Order = 1)]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetCurrentUserAsync();
            return await renderForm(user, isAdminEdit: false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserProfileViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var pid = _protectionProviderService.Decrypt(model.Pid);
                if (string.IsNullOrWhiteSpace(pid))
                {
                    return View("Error");
                }

                if (pid != _userManager.GetCurrentUserId() &&
                    !_roleManager.IsCurrentUserInRole(ConstantRoles.Admin))
                {
                    _logger.LogWarning($"سعی در دسترسی غیرمجاز به ویرایش اطلاعات کاربر {pid}");
                    return View("Error");
                }

                var user = await _userManager.FindByIdAsync(pid);
                if (user == null)
                {
                    return View("NotFound");
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.TwoFactorEnabled = model.TwoFactorEnabled;
                user.Location = model.Location;

                updateUserBirthDate(model, user);

                if (!await updateUserName(model, user))
                {
                    return View(viewName: nameof(Index), model: model);
                }

                if (!await updateUserAvatarImage(model, user))
                {
                    return View(viewName: nameof(Index), model: model);
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    if (!model.IsAdminEdit)
                    {
                        // reflect the changes in the current user's Identity cookie
                        await _signInManager.RefreshSignInAsync(user);
                    }

                    return RedirectToAction(nameof(Index), "UserCard", routeValues: new { id = user.Id });
                }

                ModelState.AddModelError("", updateResult.DumpErrors(useHtmlNewLine: true));
            }
            return View(viewName: nameof(Index), model: model);
        }

        /// <summary>
        /// For [Remote] validation
        /// </summary>
        [AjaxOnly, HttpPost, ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ValidateUsername(string username, string pid)
        {
            pid = _protectionProviderService.Decrypt(pid);
            if (string.IsNullOrWhiteSpace(pid))
            {
                return Json("اطلاعات وارد شده معتبر نیست.");
            }

            var user = await _userManager.FindByIdAsync(pid);
            user.UserName = username;

            var result = await _userValidator.ValidateAsync((UserManager<User>)_userManager, user);
            return Json(result.Succeeded ? "true" : result.DumpErrors(useHtmlNewLine: true));
        }

        private static void updateUserBirthDate(UserProfileViewModel model, User user)
        {
            if (model.DateOfBirthYear.HasValue &&
                model.DateOfBirthMonth.HasValue &&
                model.DateOfBirthDay.HasValue)
            {
                var date =
                    $"{model.DateOfBirthYear.Value.ToString()}/{model.DateOfBirthMonth.Value.ToString("00")}/{model.DateOfBirthDay.Value.ToString("00")}";
                user.BirthDate = date.ToGregorianDateTimeOffset();
            }
            else
            {
                user.BirthDate = null;
            }
        }

        private async Task<IActionResult> renderForm(User user, bool isAdminEdit)
        {
            _usersPhotoService.SetUserDefaultPhoto(user);

            var userProfile = new UserProfileViewModel
            {
                IsAdminEdit = isAdminEdit,
                PhotoFileName = user.PhotoFileName,
                Location = user.Location,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Pid = _protectionProviderService.Encrypt(user.Id.ToString()),
                TwoFactorEnabled = user.TwoFactorEnabled,
                IsPasswordTooOld = await _usedPasswordsService.IsLastUserPasswordTooOldAsync(user.Id)
            };

            if (user.BirthDate.HasValue)
            {
                var pDateParts = user.BirthDate.Value.ToPersianYearMonthDay(DateTimeOffsetPart.DateTime);
                //userProfile.DateOfBirthYear = pDateParts.;
                //userProfile.DateOfBirthMonth = pDateParts.Item2;
                //userProfile.DateOfBirthDay = pDateParts.Item3;
            }

            return View(viewName: nameof(Index), model: userProfile);
        }

        private async Task<bool> updateUserAvatarImage(UserProfileViewModel model, User user)
        {
            _usersPhotoService.SetUserDefaultPhoto(user);

            var photoFile = model.Photo;
            if (photoFile != null && photoFile.Length > 0)
            {
                var imageOptions = _siteOptions.Value.UserAvatarImageOptions;
                if (!photoFile.IsValidImageFile(maxWidth: imageOptions.MaxWidth, maxHeight: imageOptions.MaxHeight))
                {
                    this.ModelState.AddModelError("",
                        $"حداکثر اندازه تصویر قابل ارسال {imageOptions.MaxHeight} در {imageOptions.MaxWidth} پیکسل است");
                    model.PhotoFileName = user.PhotoFileName;
                    return false;
                }

                var uploadsRootFolder = _usersPhotoService.GetUsersAvatarsFolderPath();
                var photoFileName = $"{user.Id}{Path.GetExtension(photoFile.FileName)}";
                var filePath = Path.Combine(uploadsRootFolder, photoFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(fileStream);
                }
                user.PhotoFileName = photoFileName;
            }
            return true;
        }
        private async Task<bool> updateUserName(UserProfileViewModel model, User user)
        {
            if (user.UserName != model.UserName)
            {
                user.UserName = model.UserName;
                var userValidator =
                    await _userValidator.ValidateAsync((UserManager<User>)_userManager, user);
                if (!userValidator.Succeeded)
                {
                    ModelState.AddModelError("", userValidator.DumpErrors(useHtmlNewLine: true));
                    return false;
                }
            }
            return true;
        }
    }
}