using System.Security.Claims;
using HMS.Common.GuardToolkit;
using HMS.DataLayer.Context;
using HMS.Entities.Identity;
using HMS.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HMS.Services.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2578
    /// </summary>
    public class ApplicationRoleStore :
        RoleStore<Role, ApplicationDbContext, int, UserRole, RoleClaim>,
        IApplicationRoleStore
    {
        private readonly IUnitOfWork _uow;
        private readonly IdentityErrorDescriber _describer;

        public ApplicationRoleStore(
            IUnitOfWork uow,
            IdentityErrorDescriber describer)
            : base((ApplicationDbContext)uow, describer)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _describer = describer;
            _describer.CheckArgumentIsNull(nameof(_describer));
        }


        #region BaseClass

        protected override RoleClaim CreateRoleClaim(Role role, Claim claim)
        {
            return new RoleClaim
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }

        #endregion

        #region CustomMethods

        #endregion
    }
}