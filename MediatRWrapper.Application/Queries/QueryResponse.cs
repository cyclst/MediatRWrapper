namespace MediatRWrapper.Application.Queries
{
    public class QueryResponse
    {
        public bool IsOk { get; private set; }
        public dynamic? Content { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static QueryResponse Ok(dynamic content)
        {
            return new QueryResponse
            {
                IsOk = true,
                Content = content
            };
        }

        public static QueryResponse Error(string errorMessage)
        {
            return new QueryResponse
            {
                ErrorMessage = errorMessage

            };
        }
    }
}
