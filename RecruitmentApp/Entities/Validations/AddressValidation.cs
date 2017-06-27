using FluentValidation;
using RecruitmentApp.Properties;

namespace RecruitmentApp.Entities.Validations
{
    public class AddressValidation:AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(address => address.City).NotNull();
           // RuleFor(address => address.Street).NotNull().WithMessage(Resources.AddressCityValidationMessage);

        }
    }
}
