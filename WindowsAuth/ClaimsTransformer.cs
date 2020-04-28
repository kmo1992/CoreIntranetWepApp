using Microsoft.AspNetCore.Authentication;
using Shared.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace WindowsAuth
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://stackoverflow.com/questions/50823428/how-to-add-claims-to-windows-user"/>
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly SampleContext _context;
        
        public ClaimsTransformer(SampleContext context)
        {
            _context = context;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var ci = (ClaimsIdentity)principal.Identity;
            var adUser = _context.AdUser
                .Include(ad => ad.RoleMember)
                .ThenInclude(rm => rm.Role)
                .SingleOrDefault(ad => ad.UserName == ci.Name);

            if (adUser != null)
            {
                var roleMembers = adUser.RoleMember.ToList();

                foreach(RoleMember rm in roleMembers)
                {
                    var c = new Claim(ci.RoleClaimType, rm.Role.RoleName);
                    ci.AddClaim(c);
                }
            }
            
            return Task.FromResult(principal);
        }
    }
}
