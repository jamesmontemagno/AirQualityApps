using AirQualityApp.Shared.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AirQualityMaui.ViewModels;

public partial class AirQualityViewModel : ObservableObject
{
    AQIDataService dataService;
    public AirQualityViewModel(AQIDataService dataService)
    { 
        this.dataService = dataService;
    }

    [ObservableProperty]
    string location;

    [ObservableProperty]
    string current;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !isBusy;

    [RelayCommand]
    async Task GetAQIAsync()
    {

        //check internet first
        if(Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            Location = "N/A";
            return;
        }

        try
        {
            IsBusy = true;
            var c = await dataService.GetAQIAsync(Location);
            Current = c;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.ToString(), "OK");
        }
        finally
        {
            IsBusy = false; 
        }
    }
}
