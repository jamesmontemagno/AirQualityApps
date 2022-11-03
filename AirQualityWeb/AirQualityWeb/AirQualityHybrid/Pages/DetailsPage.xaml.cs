namespace AirQualityHybrid.Pages;


[QueryProperty(nameof(Location), nameof(Location))]
public partial class DetailsPage : ContentPage
{
	public string Location { get; set; }
	public DetailsPage()
	{
		InitializeComponent();
	}

    bool init;
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (init)
            return;
        init = true;
        MyComponent.Parameters = new Dictionary<string, object?>
        {
            { "Location", Location }
        };
    }
}