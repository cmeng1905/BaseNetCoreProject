using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Login
{
    public class LoginValidator:AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(s => s.Username)
                .NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");

            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("Şifre Boş Olamaz.");
        }
    }
}
