using Furion.EventBusSamples.Handlers;

var builder = WebApplication.CreateBuilder(args).UseFurion();

// Add services to the container.

// ע���¼�����
builder.Services.AddEventBus(builder.Configuration);
builder.Services.AddEventHandler<UserEventHandler>();

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
