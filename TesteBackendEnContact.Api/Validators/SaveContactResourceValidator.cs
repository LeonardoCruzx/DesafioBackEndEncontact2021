using FluentValidation;
using TesteBackendEnContact.Api.Resources.Contact;

namespace TesteBackendEnContact.Api.Validators
{
    public class SaveContactResourceValidator : AbstractValidator<SaveContactResource>
    {
        public SaveContactResourceValidator()
        {
            RuleFor(c => c.ContactBookId)
                .NotEmpty().WithMessage("The ContactBookId field is required.")
                .NotNull().WithMessage("The ContactBookId field is required.")
                .GreaterThan(0).WithMessage("The ContactBookId field must be greater than 0.")
                .LessThanOrEqualTo(int.MaxValue).WithMessage("The ContactBookId field must be less than or equal to 2147483647.");
        }
    }
}