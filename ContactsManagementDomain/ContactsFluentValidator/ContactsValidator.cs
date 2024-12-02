using ContactsManagementDomain.Entities;
using FluentValidation;

namespace ContactsManagementDomain.ContactsFluentValidator
{
    public class ContactsValidator: AbstractValidator<Contacts>
    {
        public ContactsValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("A valid Email is required.");
        }
    }
}
