﻿namespace SurveyBasket.Services;

public interface IAuthServices
{
    Task<AuthResponse> GetTokenAsync(string email, string password, CancellationToken cancellationToken);

}
