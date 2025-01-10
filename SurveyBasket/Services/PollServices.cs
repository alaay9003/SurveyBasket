namespace SurveyBasket.Services;

public class PollServices(ApplicationDbContext dbContext) : IPollServices
{
    private readonly ApplicationDbContext _Context=dbContext;

    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default) => 
        await _Context.Polls.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Poll?> GetAsync(int id, CancellationToken cancellationToken = default) => 
        await _Context.Polls.FindAsync(id, cancellationToken);

    public async Task<Poll> AddAsync(Poll poll, CancellationToken cancellationToken = default)
    {
        await _Context.Polls.AddAsync(poll, cancellationToken);
        await _Context.SaveChangesAsync(cancellationToken);
        return poll;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var currentPoll =await GetAsync(id);
        if (currentPoll is null)
            return false;

        _Context.Polls.Remove(currentPoll);
        await _Context.SaveChangesAsync(cancellationToken);
        return true;

    }

    public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken = default)
    {
        var currentPoll =await GetAsync(id);
        if (currentPoll is null)
            return false;
        currentPoll.Title = poll.Title;
        currentPoll.Description = poll.Description;
        currentPoll.EndAt = poll.EndAt;
        currentPoll.StartedAt = poll.StartedAt;

        await _Context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

