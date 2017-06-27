using FluentValidation;

namespace RecruitmentApp.Entities.Validations
{
    public class ConsumerValidation : AbstractValidator<Consumer>
    {
        private const string PhoneNumberRegEx = @"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{3})/";

        public ConsumerValidation()
        {
          //  RuleFor(cons => cons.Number).Matches(PhoneNumberRegEx);
        }
    }
}