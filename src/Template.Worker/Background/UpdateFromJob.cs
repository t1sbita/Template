using Quartz;
using System.Diagnostics.CodeAnalysis;

namespace Template.Worker.Background
{
    [ExcludeFromCodeCoverage]
    [DisallowConcurrentExecution]
    public class UpdateFromJob : IJob
    {
        private readonly ILogger<UpdateFromJob> _logger;

        public UpdateFromJob(ILogger<UpdateFromJob> logger)
        {
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Task Execute AutoUpdateDb");

            try
            {
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, string.Format("{0}.{1}", typeof(UpdateFromJob), nameof(Execute)));
                throw;
            }
            finally
            {
                _logger.LogInformation("Next job execution at " + context.NextFireTimeUtc?.LocalDateTime);
            }

        }

    }
}
