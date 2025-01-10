namespace SurveyBasket.Contracts.Poll;

public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
{
    public CreatePollRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(3, 10);

        RuleFor(x => DateOnly.FromDateTime(x.StartedAt))
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
    }

}
