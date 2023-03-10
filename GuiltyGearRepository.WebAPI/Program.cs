using GuiltyGearRepository.WebAPI.Contexts;
using GuiltyGearRepository.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

builder.Services.AddDbContext<GuiltyGearDb>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("GG_DB")));

builder.Services.AddScoped<XrdRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();

