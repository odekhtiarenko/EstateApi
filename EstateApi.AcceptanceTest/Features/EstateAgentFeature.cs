using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System.Threading.Tasks;

namespace EstateApi.AcceptanceTest.Features
{
    public partial class EstateAgentFeature
    {
        [Scenario]
        public async Task TopRealEstateAgents()
        {
            await Runner.AddAsyncSteps(_ => Given_CallToTopRealEstateAgentsByLocation())
                        .AddSteps(Then_Top10RealEstateAgentsShoulBeRetrivedInDescendingOrder)
                                                .RunAsync();
        }

        [Scenario]
        public async Task TopRealEstateAgentsFilter()
        {
            await Runner.AddAsyncSteps(_ => Given_CallToTopRealEstateAgentsByLocationAndFilter())
                        .AddSteps(Then_Top10RealEstateAgentsShoulBeRetrivedInDescendingOrder)
                                                .RunAsync();
        }
    }
}
