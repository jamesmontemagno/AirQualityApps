namespace AirQualityWeb.Data;
public class AQIDataService
{
    public List<AQIData> Data { get; } = new List<AQIData>();
    public async Task GetAQIAsync()
    { 
        var client = new HttpClient();

        foreach(var item in Data)
        {
            var url = $"https://airqualityfunctions20220929140700.azurewebsites.net/api/GetAirQuality?location={item.Location}";
            item.AQI = await client.GetStringAsync(url);
        }
    }
}
