using FluentValidation;
using T9Spelling.Models.RequestModels;

namespace T9Spelling.Models.ValidationModels
{
    public class T9ValidationModel : AbstractValidator<T9SpellingRequestModel>
    {
        public T9ValidationModel()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(1000)
                .WithMessage("Length of text should be between 1 and 1000 characters.");
        }
    }
}
