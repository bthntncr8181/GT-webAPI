using FluentValidation;
using GTBack.Core.DTO;
using GTBack.Service.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Validation
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage(ValidationMessages.Email_Not_Empty)
                .EmailAddress().WithMessage(ValidationMessages.Email_Invalid)
                .MaximumLength(128).WithMessage(ValidationMessages.Max_Length);
            RuleFor(x => x.UserName)
       .NotEmpty().WithMessage(ValidationMessages.Username_Not_Empty)
    
       .MaximumLength(128).WithMessage(ValidationMessages.Max_Length);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.Name_Not_Empty);

            RuleFor(x => x.password)
                .NotEmpty().WithMessage(ValidationMessages.Password_Not_Empty)
                .MaximumLength(128).WithMessage(ValidationMessages.Max_Length)
                .MinimumLength(6).WithMessage(ValidationMessages.Min_Length);

        
        }
    }
}
