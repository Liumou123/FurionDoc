using Furion.TestProject.Controllers;

var builder = WebApplication.CreateBuilder(args).UseFurion();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Furion.TestProject", Version = "v1" });
});

builder.Services.AddAppOptions<TestSettingsOptions>(builder.Configuration, options =>
{
    options.Name ??= "Furion";
});
builder.Services.AddAppOptions<Test2SettingsOptions>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Furion.TestProject v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
