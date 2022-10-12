# AirQualityApps

AQI apps built with [.NET](https://dot.net) built on Azure Functions for Blazor, Microsoft Teams, and Chat Commands in Microsoft Teams!

Get API keys for:
* AirVisual: https://www.iqair.com/air-pollution-data-api
* Azure Maps: https://azure.microsoft.com/products/azure-maps/#azuremaps-overview

Create a `local.settings.json` with the following info and your API Keys:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AQI_API_KEY": "",
    "MAPS_API_KEY": ""
  }
}
```

Learn more about Teams development at https://aka.ms/teams-toolkit-vs
