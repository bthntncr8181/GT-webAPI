using FluentValidation;
using GTBack.Core.DTO;
using GTBack.Service.Utilities.Consts;

namespace GTBack.Service.Validation;

public class EventCreateValidator : AbstractValidator<EventAddRequestDTO>
{
    public EventCreateValidator()
    {
        //BURASI DOLDURULACAK
        RuleFor(x => x.Mail)
            .NotEmpty().WithMessage(ValidationMessages.Email_Not_Empty)
            .EmailAddress().WithMessage(ValidationMessages.Email_Invalid)
            .MaximumLength(128).WithMessage(ValidationMessages.Max_Length);
       
    }
}