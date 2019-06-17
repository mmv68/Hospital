using HMS.Common.GuardToolkit;
using HMS.Common.IdentityToolkit;
using HMS.Entities.Identity;
using HMS.Services.Contracts.Identity;
using HMS.ViewModels.Identity;
using DNTBreadCrumb.Core;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using HMS.ViewModels.Identity.Settings;
using DNTCommon.Web.Core;
using HMS.Services.Identity;

namespace HMS.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [Authorize(Roles = ConstantRoles.Admin)]
    [BreadCrumb(Title = "بازیابی کلمه‌ی عبور", UseDefaultRouteUrl = true, Order = 0)]
    public class ForgotPasswordController : Controller
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        public ForgotPasswordController(
            IApplicationUserManager userManager,
            IPasswordValidator<User> passwordValidator,
            IOptionsSnapshot<SiteSettings> siteOptions)
        {
            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _passwordValidator = passwordValidator;
            _passwordValidator.CheckArgumentIsNull(nameof(_passwordValidator));

            _siteOptions = siteOptions;
            _siteOptions.CheckArgumentIsNull(nameof(_siteOptions));
        }

        [BreadCrumb(Title = "تائید کلمه‌ی عبور فراموش شده", Order = 1)]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [BreadCrumb(Title = "اطلاعات کاربر", Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// For [Remote] validation
        /// </summary>
        [AjaxOnly, HttpPost, ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ValidatePassword(string password, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json("نام کاربری وارد شده معتبر نمی باشد");
            }

            var result = await _passwordValidator.ValidateAsync(
                (UserManager<User>)_userManager, user, password);
            return Json(result.Succeeded ? "true" : result.DumpErrors(useHtmlNewLine: true));
        }
        /// <summary>
        /// For [Remote] validation
        /// </summary>
        [AjaxOnly, HttpPost, ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ValidateUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json("نام کاربری وارد شده معتبر نمی باشد");
            }
            return Json("true");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(CaptchaGeneratorLanguage = DNTCaptcha.Core.Providers.Language.Persian)]
        public async Task<IActionResult> Index(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    return View("Error");
                }
                ViewData["UserName"] = model.UserName;
                return View("ResetPassword");
            }
            return View(model);
        }

        [BreadCrumb(Title = "تغییر کلمه‌ی عبور", Order = 1)]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            model.Code= await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }

        [BreadCrumb(Title = "تائیدیه تغییر کلمه‌ی عبور", Order = 1)]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}