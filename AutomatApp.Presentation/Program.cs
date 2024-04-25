using AutomatApp.Application.ApplicationDependencies;
using AutomatApp.Domain.InterfacesRepository;
using AutomatApp.Infrastructure;
using AutomatApp.Infrastructure.DbRepositories;
using AutomatApp.Infrastructure.InfrastructureDependencies;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationDependencies();

builder.Services.AddDbContext<AutomatDbContext>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var app = builder.Build();

await app.SeedAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
