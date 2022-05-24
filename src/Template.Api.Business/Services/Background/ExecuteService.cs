using Template.Api.Core.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Template.Api.Business.Services.Background
{
    [ExcludeFromCodeCoverage]
    public class ExecuteService : BackgroundService 
    {
        private ILogger _logger;
        private readonly int TEMP_BACKGROUND_DELAY = 0;
        private readonly IServiceProvider _serviceProvider;

        public ExecuteService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            TEMP_BACKGROUND_DELAY = int.Parse("300000");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                if (!isRunning && !isFirstExecution)
                {
                    isRunning = true;
                    await Process();
                }

                isFirstExecution = false;
                await Task.Delay(TEMP_BACKGROUND_DELAY, stoppingToken);
            }
        }

        protected override async Task Process()
        {
            try
            {
                var scope = _serviceProvider.CreateScope();
                _logger = scope.ServiceProvider.GetRequiredService<ILogger>();

                _logger.LogInformation("Method Process ImplantarDDUI");

                //Method to execute in background here

                isRunning = false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, string.Format("{0}.{1}", typeof(ExecuteService), nameof(Process)));
                isRunning = false;
            }
        }
    }
}
