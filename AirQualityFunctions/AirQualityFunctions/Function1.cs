using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace AirQualityFunctions
{
    public static class AirQuality
    {
        [FunctionName("GetAirQuality")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string location = req.Query["location"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            location = location ?? data?.location;


            var mapsKey = Environment.GetEnvironmentVariable("MAPS_API_KEY");
            var mapsUrl = $"https://atlas.microsoft.com/geocode?api-version=2022-02-01-preview&query={location}&subscription-key={mapsKey}";

            var http = new HttpClient();
            var geo = await http.GetStringAsync(mapsUrl);
            var geoData = JsonConvert.DeserializeObject<GeocodingData>(geo);


            var aqiKey = Environment.GetEnvironmentVariable("AQI_API_KEY");
            var lat = geoData.features[0].geometry.coordinates[1];
            var lon = geoData.features[0].geometry.coordinates[0];
            var aqiUrl = $"https://api.airvisual.com/v2/nearest_city?lat={lat}&lon={lon}&key={aqiKey}";

            var aqi = await http.GetStringAsync(aqiUrl);
            var aqiData = JsonConvert.DeserializeObject<AQIData>(aqi);

            return new OkObjectResult(aqiData.data.current.pollution.aqius.ToString());
        }
    }
}
