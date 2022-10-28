using AirQualityApp.Shared.Data;
using AirQualityMaui.ViewModels;

namespace AirQualityMaui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AirQualityViewModel>();
        builder.Services.AddSingleton<AQIDataService>();

        return builder.Build();
	}
}
