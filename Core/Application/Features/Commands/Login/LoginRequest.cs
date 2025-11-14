using Application.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
