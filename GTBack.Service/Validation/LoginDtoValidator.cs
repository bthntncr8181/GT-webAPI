using FluentValidation;
using GTBack.Core.DTO.Request;
using GTBack.Service.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Validation
{

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage(ValidationMessages.Username_Not_Empty)
                   
                    .MaximumLength(128).WithMessage(ValidationMessages.Max_Length);

         

            RuleFor(x => x.password)
                .NotEmpty().WithMessage(ValidationMessages.Password_Not_Empty)
                .MaximumLength(128).WithMessage(ValidationMessages.Max_Length)
                .MinimumLength(3).WithMessage(ValidationMessages.Min_Length);
        }
    }
}
