using AirQualityHybrid.Pages;

namespace AirQualityHybrid;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
	}
}
