﻿using Furion.JobScheduler;

namespace Furion.SchedulerSamples;

public class TestPeriodJob : IJob
{
    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken cancellationToken)
    {
        Console.WriteLine($"<{context.JobId}> {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        await Task.CompletedTask;
    }
}