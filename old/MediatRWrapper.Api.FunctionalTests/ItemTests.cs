using FluentAssertions;
using PureGym.IdentityServer.Web.IntegrationTests;

namespace MediatRWrapper.Api.FunctionalTests
{
    public class ItemTests : TestFixtureBase
    {
        public ItemTests(TestApplicationFactory factory) : base(factory)
        { }

        [Fact]
        public async Task GivenMemberWhenAttemptLoginWithValidCredentialsThenLoginSuccessfully()
        {
            // ARRANGE
            var x = await Client.PostAsync("/Item?itemName=testing", null);

            // ACT
            var response = await Client.GetAsync("/Item");
            var item = await response.Content.ReadAsStringAsync();

            // ASSERT
            response.IsSuccessStatusCode.Should().BeTrue();
            item.Should().Be("testing");
        }

    }
}