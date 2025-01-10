namespace SurveyBasket.Contracts.Poll;

public record PollResponse(
    int Id,
    string Title,
    string Notes,
    DateTime StartedAt,
    DateTime EndAt,
    bool IsPublished
    );
