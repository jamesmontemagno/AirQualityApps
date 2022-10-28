using AirQualityMaui.ViewModels;

namespace AirQualityMaui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(AirQualityViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count+=10;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

