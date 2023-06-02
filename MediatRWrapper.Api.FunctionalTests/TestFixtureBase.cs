namespace PureGym.IdentityServer.Web.IntegrationTests
{
    public abstract class TestFixtureBase : IClassFixture<TestApplicationFactory>
    {
        protected TestApplicationFactory Factory { get; }
        protected HttpClient Client { get; }

        protected TestFixtureBase(TestApplicationFactory factory)
        {
            Factory = factory;
            Client = factory.CreateClient();
        }
    }
}
