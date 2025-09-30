using ApiService;
using Frontend.Components;

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

builder.Services.AddScoped<ApiClient>();


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
