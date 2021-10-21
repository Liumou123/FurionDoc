
var builder = WebApplication.CreateBuilder(args).UseFurion();

// Add services to the container.
builder.Configuration.AddFile("furion.json includeEnvironment=true reloadOnChange=true");
builder.Configuration.AddFile("furion.xml");
builder.Configuration.AddFile("furion.ini");

builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>()
{
    ["Memory"] = "Value",
    ["Memory:Title"] = "Furion"
});

builder.Configuration.AddTxtConfiguration(options =>
{
    options.Path = Path.Combine(Directory.GetCurrentDirectory(), "values.txt");
});

builder.Configuration.AddKeyPerFile(Path.Combine(Directory.GetCurrentDirectory(), "key-per-file"));

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
