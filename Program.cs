using uiux.Components;
using uiux.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<OsakaDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

if (!app.Environment.IsDevelopment())
{
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        try
        {
            var server = app.Services.GetRequiredService<Microsoft.AspNetCore.Hosting.Server.IServer>();
            var addresses = server.Features.Get<Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>()?.Addresses;
            if (addresses != null)
            {
                var address = addresses.FirstOrDefault(a => a.StartsWith("https://")) 
                           ?? addresses.FirstOrDefault(a => a.StartsWith("http://"));
                
                if (address != null)
                {
                    address = address.Replace("[::]", "localhost").Replace("*", "localhost").Replace("0.0.0.0", "localhost");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = address,
                        UseShellExecute = true
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Browser Launcher] Failed to launch browser: {ex.Message}");
        }
    });
}

app.Run();