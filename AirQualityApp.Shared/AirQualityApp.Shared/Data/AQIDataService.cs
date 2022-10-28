namespace AirQualityApp.Shared.Data;
public class AQIDataService
{
    HttpClient httpClient = new();
    public List<AQIData> Data { get; } = new List<AQIData>();
    public async Task GetAQIAsync()
    { 
        foreach(var item in Data)
        {
            var url = $"https://airqualityfunctions20220929140700.azurewebsites.net/api/GetAirQuality?location={item.Location}";
            item.AQI = await httpClient.GetStringAsync(url);
        }
    }

    public async Task<string> GetAQIAsync(string location)
    {
        var url = $"https://airqualityfunctions20220929140700.azurewebsites.net/api/GetAirQuality?location={location}";
        return await httpClient.GetStringAsync(url);
    }
}
