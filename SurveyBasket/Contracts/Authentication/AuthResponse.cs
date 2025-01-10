namespace SurveyBasket.Contracts.Authentication;

public record AuthResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Token,
    int ExpireIn
    );
