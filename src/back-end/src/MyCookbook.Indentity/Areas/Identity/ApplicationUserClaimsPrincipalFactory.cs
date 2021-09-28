using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyCookbook.Indentity.Areas.Identity
{
    public class ApplicationUserClaimsPrincipalFactory :
        UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options)
                : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("full_name", user.Name));
            identity.AddClaim(new Claim("user_id", user.Id));

            return identity;
        }
    }
}
