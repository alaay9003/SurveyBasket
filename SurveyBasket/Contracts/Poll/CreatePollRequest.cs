namespace SurveyBasket.Contracts.Poll;

public record CreatePollRequest(
    string Title,
    string Notes,
    DateTime StartedAt,
    DateTime EndAt,
    bool IsPublished
    );
