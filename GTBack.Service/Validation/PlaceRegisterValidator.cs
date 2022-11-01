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
    public class PlaceRegisterValidator : AbstractValidator<PlaceDto>
    {
        public PlaceRegisterValidator()
        {

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage(ValidationMessages.Email_Not_Empty)
                .EmailAddress().WithMessage(ValidationMessages.Email_Invalid)
                .MaximumLength(128).WithMessage(ValidationMessages.Max_Length);
           
       
       


        }
    }
}
