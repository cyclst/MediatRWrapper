namespace MediatRWrapper.Application.Commands
{
    public class CommandResult<T> : CommandResult
    {
        public T Content { get; }

        private CommandResult()
        {
        }

        public CommandResult(T content)
        {
            Content = content;
            Success = true;
        }

        public static CommandResult<T> Error(string errorMessage = "")
        {
            return new CommandResult<T> 
            { 
                Success = false, 
                ErrorMessage = errorMessage
            };
        }
    }

    public class CommandResult
    {
        public bool Success { get; protected set; }
        public string ErrorMessage { get; protected set; } = "";

        public static CommandResult Ok()
        {
            return new CommandResult()
            {
                Success = true
            };
        }

        public static CommandResult<T> Ok<T>(T content)
        {
            return new CommandResult<T>(content);
        }

        public static CommandResult Error(string errorMessage = "")
        {
            return new CommandResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
