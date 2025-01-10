namespace SurveyBasket.Services;

public class AuthServices(UserManager<ApplicationUser> userManager) : IAuthServices
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public async Task<AuthResponse> GetTokenAsync(string email, string password, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);

    }
}
