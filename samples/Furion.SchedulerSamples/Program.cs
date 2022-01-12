using Furion.Schedule;
using Furion.SchedulerSamples;
using Furion.TimeCrontab;

var builder = WebApplication.CreateBuilder(args).UseFurion();

// Add services to the container.
builder.Services.AddScoped<ITestScopedService, TestScopedService>();
builder.Services.AddTransient<ITestTransientService, TestTransientService>();

builder.Services.AddSchedule(options =>
{
    options.AddJob(JobBuilder.Create<TestCronJob>()
                                            .WithIdentity("cron_job")
                                            .SetWithExecutionLog(true)
                                            .BindTriggers(
                                                TriggerBuilder.CreateCron("* * * * *")
                                            ));

    options.AddJob(JobBuilder.Create<TestPeriodJob>()
                                             .WithIdentity("period_trigger")
                                             .BindTriggers(
                                                TriggerBuilder.CreatePeriod(5000),
                                                TriggerBuilder.CreateCron("*/17 * * * * *", CronStringFormat.WithSeconds)
                                              ));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
