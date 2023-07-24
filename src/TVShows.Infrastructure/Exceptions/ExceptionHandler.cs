using Microsoft.Extensions.Logging;

namespace TVShows.Infrastructure
{
    /// <summary>
    /// ExceptionHandler custom exception handler.
    /// </summary>
    public class ExceptionHandler : Exception
    {
        public ExceptionHandler(string message) : base(message) { }

        public void LogException(ILogger logger)
        {
            logger.LogError(this, this.Message);
        }
    }
}
