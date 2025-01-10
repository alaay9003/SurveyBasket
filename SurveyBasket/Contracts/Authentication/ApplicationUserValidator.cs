namespace SurveyBasket.Contracts.Authentication;

public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
{
    public ApplicationUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.FirstName).Length(3, 10);

        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.LastName).Length(3, 10);


    }

}
