using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args).Inject();  // ע�� Furion
var app = builder.Build();
app.Run();
