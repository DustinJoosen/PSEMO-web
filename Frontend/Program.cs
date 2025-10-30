using Frontend.Components;
using Blazored.LocalStorage;
using Business.Services.Interfaces;
using Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddScoped(sp =>
{
    string backendApiUrl = builder.Configuration["BackendApiUrl"] ??
        throw new InvalidOperationException("BackendApiUrl not set in configuration");

    return new HttpClient { BaseAddress = new Uri(backendApiUrl) };
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPasswordPolicyService, PasswordPolicyService>();
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
