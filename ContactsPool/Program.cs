using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Adding services to the IOC container (Dependency Injection)
builder.Services.AddSingleton<ICountriesService, CountriesService>();
builder.Services.AddSingleton<IPersonsService, PersonsService>();
builder.Services.AddDbContext<PersonDbContext>(options => options.UseSqlServer());

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
