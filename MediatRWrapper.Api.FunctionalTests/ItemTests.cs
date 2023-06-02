using FluentAssertions;
using Newtonsoft.Json;
using PureGym.IdentityServer.Web.IntegrationTests;

namespace MediatRWrapper.Api.FunctionalTests
{
    public class ItemTests : TestFixtureBase
    {
        public ItemTests(TestApplicationFactory factory) : base(factory)
        { }

        [Fact]
        public async Task Test()
        {
            var response = await Client.PostAsync("/Item?name=testing", null);
            var content = await response.Content.ReadAsStringAsync();
            var id = JsonConvert.DeserializeObject<Guid>(content);

            response.IsSuccessStatusCode.Should().BeTrue();

            response = await Client.GetAsync("/Item");
            var item = await response.Content.ReadAsStringAsync();

            response.IsSuccessStatusCode.Should().BeTrue();
            item.Should().Be("testing");

            response = await Client.PutAsync($"/Item?id={id}&name=changed", null);

            response.IsSuccessStatusCode.Should().BeTrue();

            response = await Client.GetAsync("/Item");
            item = await response.Content.ReadAsStringAsync();

            response.IsSuccessStatusCode.Should().BeTrue();
            item.Should().Be("changed");
        }

    }
}