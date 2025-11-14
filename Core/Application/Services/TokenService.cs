using Application.Abstractions.Services;
using Application.Consts;
using Application.Options;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService(JwtAuth _jwtAuth) : ITokenService
    {
        public string GenerateAccessToken(AppUser user)
        {
            var claims = GetUserClaimsIdentity(user);
            return GenerateToken(claims);
        }
        private List<Claim> GetUserClaimsIdentity(AppUser user)
        {
            var claims = new List<Claim>
                {
                    new Claim(UserClaimTypes.UserName, user.UserName),
                    new Claim(UserClaimTypes.Email, user.Email),
                    new Claim(UserClaimTypes.Tckn, user.TCKimlikNo ?? string.Empty),
                };

            foreach (var role in user.AppUserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.AppRole.Name));
            }
            return claims;
        }
        private string GenerateToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtAuth.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }
    }
}
