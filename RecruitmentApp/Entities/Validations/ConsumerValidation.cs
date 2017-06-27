using FluentValidation;

namespace RecruitmentApp.Entities.Validations
{
    public class ConsumerValidation : AbstractValidator<Consumer>
    {
        private const string PhoneNumberRegEx = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{3}$";

        public ConsumerValidation()
        {
              RuleFor(cons => cons.Number).Matches(PhoneNumberRegEx).WithMessage("Phone number should be in format XXX XXX XXX");
        }
    }
}