using System;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Identity;

namespace HMS.ViewModels.Identity.Settings
{
    public class SiteSettings
    {
        public AdminUserSeed AdminUserSeed { get; set; }
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public int NotAllowedPreviouslyUsedPasswords { get; set; }
        public int ChangePasswordReminderDays { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
        public ActiveDatabase ActiveDatabase { get; set; }
        public string UsersAvatarsFolder { get; set; }
        public string UserDefaultPhoto { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public LockoutOptions LockoutOptions { get; set; }
        public UserAvatarImageOptions UserAvatarImageOptions { get; set; }
        public string[] PasswordsBanList { get; set; }
    }
}