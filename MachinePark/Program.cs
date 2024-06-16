using MachinePark.Components;
using Microsoft.EntityFrameworkCore;
using Resources.Data.Data;
using Resources.Data.Repositories;
using Resources.Enteties.IRepositories;
using Resources.Enteties.Repositories;
using Resources.Enteties.State;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<MachineDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:MachineDbContext"]));

builder.Services.AddScoped<IMachineRepository, MachineRepository>();
builder.Services.AddScoped<IDatabaseCleaner, DatabaseCleaner>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<MachineStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Slow as hell, look up implementing the Interceptor instead.
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<MachineDbContext>();

if (await dbContext.Database.CanConnectAsync())
{
    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.MigrateAsync();

    try
    {
        var cleaner = scope.ServiceProvider.GetRequiredService<IDatabaseCleaner>();
        await cleaner.DeleteDbAsync();
        await cleaner.CreateDbAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while deleting or creating the database: {ex.Message}");
    }
}
else
{
    Console.WriteLine("Cannot connect to the database.");
}

await app.RunAsync();

