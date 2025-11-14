using Application.Abstractions.Services;
using Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.Login
{
    public class LoginHandler(AppDataContext _appDataContext, ILdapService _ldapService, ITokenService _tokenService) : IRequestHandler<LoginRequest, LoginResponse>
    {
        async Task<LoginResponse> IRequestHandler<LoginRequest, LoginResponse>.Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (_ldapService.Authenticate(request.Username, request.Password))
            {
                var user = await _appDataContext.Users.FirstOrDefaultAsync(u => u.UserName == request.Username && u.AktifMi, cancellationToken);
                if (user != null)
                {
                    if (user.AppUserRoles.Any(s => s.ExpirationDate > DateTime.Now))
                        return new LoginResponse(user.UserName, _tokenService.GenerateAccessToken(user));
                }
                throw new Exception("Kullanıcı yetkisi bulunmamaktadır.");
            }
            throw new Exception("Kullanıcı adı veya şifre hatalı");
        }
    }
}
