using Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public class UserContextProvider(ClaimsPrincipal claimsPrincipal) : IUserContextProvider
    {
        public bool IsAuthenticated => claimsPrincipal.Identity is null ? false : claimsPrincipal.Identity.IsAuthenticated;
        public string UserName => GetClaimValue(claimsPrincipal.Claims, UserClaimTypes.UserName);
        public string Email => GetClaimValue(claimsPrincipal.Claims, UserClaimTypes.Email);
        public string Tckn =>GetClaimValue(claimsPrincipal.Claims, UserClaimTypes.Tckn);
        public IEnumerable<string> Roles => GetClaimValues(claimsPrincipal.Claims, ClaimTypes.Role).ToList();
        private static string GetClaimValue(IEnumerable<Claim> claims, string claimName)
        {
            try
            {
                var claim = claims.FirstOrDefault(t => t.Type == claimName);
                return claim != null ? claim.Value : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        private static IEnumerable<string> GetClaimValues(IEnumerable<Claim> claims, string claimName)
        {
            try
            {
                var filteredClaims = claims.Where(t => t.Type == claimName);
                return filteredClaims.Any() ? filteredClaims.Select(t => t.Value) : [];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
