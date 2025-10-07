using ApiService;
using Frontend.Components;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped(sp =>
{
    string backendApiUrl = builder.Configuration["BackendApiUrl"] ??
        throw new InvalidOperationException("BackendApiUrl not set in configuration");

    return new HttpClient { BaseAddress = new Uri(backendApiUrl) };
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<ILocalStorageJwtService, LocalStorageJwtService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
