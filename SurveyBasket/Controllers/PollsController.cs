using SurveyBasket.Contracts.Poll;

namespace SurveyBasket.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollServices pollServices) : ControllerBase
{
    private readonly IPollServices _pollServices = pollServices;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var polls = await _pollServices.GetAllAsync(cancellationToken);
        var response = polls.Adapt<IEnumerable<PollResponse>>();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var poll = await _pollServices.GetAsync(id, cancellationToken);
        var response = poll.Adapt<PollResponse>();
        return response is null ? NotFound() : Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePollRequest poll, CancellationToken cancellationToken = default)
    {
        var newPoll =await _pollServices.AddAsync(poll.Adapt<Poll>(), cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreatePollRequest poll
        , CancellationToken cancellationToken = default)
    {
        var isUpdted =await _pollServices.UpdateAsync(id, poll.Adapt<Poll>(), cancellationToken);
        return isUpdted ? NoContent() : NotFound(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var isDeleted =await _pollServices.DeleteAsync(id, cancellationToken);
        return isDeleted ? Ok() : NotFound();
    }

}
