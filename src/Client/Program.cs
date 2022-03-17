using Domain.Common.Interfaces;
using DataStore.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Dependency Injection Container LOL
builder.Services.AddSingleton<IUserRepository, InMemUserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapRazorPages();

app.Run();