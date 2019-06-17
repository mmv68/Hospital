using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using HMS.Common.GuardToolkit;

namespace HMS.Services.Identity
{
    /// <summary>
    /// Extending the Built-in User Validation
    /// More info: http://www.YaZahra.YaAli/post/2579
    /// </summary>
    public class CustomUserValidator : UserValidator<User>
    {
        public CustomUserValidator(
            IdentityErrorDescriber errors// How to use CustomIdentityErrorDescriber
            ) : base(errors)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            manager.Options.User.RequireUniqueEmail = false;
            // First use the built-in validator
            var result = await base.ValidateAsync(manager, user);
            var errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            // Configure validation logic for usernames

            // Extending the built-in validator
            validateUserName(user, errors);

            return !errors.Any() ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }

        private static void validateUserName(User user, List<IdentityError> errors)
        {
            var userName = user?.UserName;
            if (string.IsNullOrWhiteSpace(userName))
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    errors.Add(new IdentityError
                    {
                        Code = "UserIsNotSet",
                        Description = "لطفا اطلاعات کاربری را تکمیل کنید."
                    });
                }
                return;  // base.ValidateAsync() will cover this case
            }

            if (userName.IsNumeric() || userName.ContainsNumber())
            {
                errors.Add(new IdentityError
                {
                    Code = "BadUserNameError",
                    Description = "نام کاربری وارد شده نمی‌تواند حاوی اعداد باشد."
                });
            }

            if (userName.HasConsecutiveChars())
            {
                errors.Add(new IdentityError
                {
                    Code = "BadUserNameError",
                    Description = "نام کاربری وارد شده معتبر نیست."
                });
            }
        }
    }
}