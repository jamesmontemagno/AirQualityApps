namespace AirQualityWeb.Data;

public class AQIData
{
    public string? Location { get; set; }
    public string? AQI { get; set; }

    public string Level
    {
        get
        {
            if (string.IsNullOrWhiteSpace(AQI))
                return string.Empty;

            if(int.TryParse(AQI, out var level))
            {
                if (level >= 301)
                    return "Hazardous";
                if (level >= 201)
                    return "Very Unhealthy";
                if (level >= 151)
                    return "Unhealthy";
                if (level >= 101)
                    return "Unhealthy for Sensitive Groups";
                if (level >= 51)
                    return "Moderate";
                return "Good";
            }

            return string.Empty;
        }
    }

}