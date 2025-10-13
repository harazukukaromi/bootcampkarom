using FluentValidation;
using PenjualanBarangApi.DTOs;

namespace PenjualanBarangApi.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username wajib diisi.")
                .MinimumLength(8).WithMessage("Username minimal 8 karakter.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password wajib diisi.")
                .MinimumLength(8).WithMessage("Password minimal 8 karakter.");
        }
    }
}

