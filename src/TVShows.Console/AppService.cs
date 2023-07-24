using Microsoft.Extensions.Logging;
using TVShows.Application.Common.Interfaces;
using TVShows.Infrastructure;


namespace TVShows.Console
{
    /// <summary>
    /// Main class service.
    /// </summary>
    public class AppService
    {
        private readonly ITVShowInputHandlerService _tVShowHandler;
        private readonly ILogger<AppService> _logger;

        public AppService(
            ITVShowInputHandlerService tVShowHandler,
            ILogger<AppService> logger)
        {
            _tVShowHandler = tVShowHandler;
            _logger = logger;
            _ = Welcome();
        }

        /// <summary>
        /// Main task to run the application.
        /// </summary>
        public async Task Run()
        {
            try
            {
                while (true)
                {

                    //userInput string will be send as parameter to me handle
                    string userInput = System.Console.ReadLine().Trim().ToLower();

                    //Single validation to exit program.
                    if (userInput == "exit")
                    {
                        System.Console.WriteLine("Goodbye!");
                        break;
                    }

                    //userInput string will be send as parameter to be handle.
                    var result = await _tVShowHandler.HandleUserInput(userInput);  
                    
                    if (result.TVShows?.Count() > 0)
                    {
                        System.Console.WriteLine(result.Message);

                        foreach (var tvShow in result.TVShows)
                        {
                            System.Console.WriteLine(tvShow.ToConsoleStringFormat);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine(result.Message);
                    }

                    System.Console.WriteLine("");
                }
            }
            catch (ExceptionHandler ex)
            {
                //Save the exception log information, and throw a custom error message
                ex.LogException(_logger);
                System.Console.WriteLine(ex.Message);
            }
        }

        private async Task Welcome()
        {
            System.Console.WriteLine("Instructions: type one of the following commands to iteract with the app.");
            System.Console.WriteLine("");
            System.Console.WriteLine("'TV Show Id', if you want to add/remove the tv show to the favorites list");
            System.Console.WriteLine("'list', to see all shows");
            System.Console.WriteLine("'exit', to quit:");
            System.Console.WriteLine("");
            System.Console.WriteLine("TV Shows Availables Below");
            System.Console.WriteLine("");

            //userInput string will be send as parameter to be handle.
            var result = await _tVShowHandler.HandleUserInput("list");

            if (result.TVShows.Any())
            {
                foreach (var tvShow in result.TVShows)
                {
                    System.Console.WriteLine(tvShow.ToConsoleStringFormat);
                }
            }
        }
    }
}
