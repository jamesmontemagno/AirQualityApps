using AirQualityApp.Shared.Contracts;
using AirQualityApp.Shared.Data;
using AirQualityHybrid.Data;
using AirQualityHybrid.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace AirQualityHybrid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<AQIDataService>();

        // Pick one of these network connectivity options:

        // 1. Use the device's current connectivity
        builder.Services.AddSingleton<IConnectivity>(c => Connectivity.Current);
        builder.Services.AddSingleton<IAQConnectivity, MauiEssentialsConnectivity>();

        // 2. Assume connectivity is always available
        //builder.Services.AddSingleton<IAQConnectivity, AlwaysConnectedConnectivity>();

        // 3. Randomly change between connected and disconnected
        //builder.Services.AddSingleton<IAQConnectivity, RandomConnectedConnectivity>();

        return builder.Build();
    }
}
