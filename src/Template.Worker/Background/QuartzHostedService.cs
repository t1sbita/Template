using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Quartz;
using Quartz.Spi;
using Template.Worker.Extensions;

namespace Template.Worker.Background
{
    [ExcludeFromCodeCoverage]
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public QuartzHostedService(
            IHostApplicationLifetime hostApplicationLifetime,
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _schedulerFactory = schedulerFactory;
            _jobSchedules = jobSchedules;
            _jobFactory = jobFactory;
        }
        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach (var jobSchedule in _jobSchedules)
            {
                var job = CreateJob(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

#pragma warning disable CS1998 // O método assíncrono não possui operadores 'await' e será executado de forma síncrona
        public async Task StopAsync(CancellationToken cancellationToken)
#pragma warning restore CS1998 
        {
            _hostApplicationLifetime.StopApplication();
        }

        private static IJobDetail CreateJob(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobType.FullName)
                .WithDescription(jobType.Name)
                .Build();
        }

        private static ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{schedule.JobType.FullName}.trigger")
                .WithCronSchedule(schedule.CronExpression)
                .WithDescription(schedule.CronExpression)
                .Build();
        }
    }
}
