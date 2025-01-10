using MapsterMapper;
using SurveyBasket.Contracts.Poll;

namespace SurveyBasket.Mapping;

public class MappingConfigration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePollRequest , Poll>().Map(src => src.Description , des => des.Notes);
        config.NewConfig< Poll , PollResponse>().Map(des => des.Notes ,src => src.Description );
    }
}
