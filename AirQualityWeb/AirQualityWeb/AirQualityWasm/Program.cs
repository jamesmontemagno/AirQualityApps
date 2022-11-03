using AirQualityApp.Shared.Contracts;
using AirQualityApp.Shared.Data;
using AirQualityWasm;
using AirQualityWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<AQIDataService>();

// Pick one of these network connectivity options:

// 1. Use the device's current connectivity
builder.Services.AddSingleton<IAQConnectivity, JSInteropNetworkConnectivity>();

// 2. Assume connectivity is always available
//builder.Services.AddSingleton<IAQConnectivity, AlwaysConnectedConnectivity>();

// 3. Randomly change between connected and disconnected
//builder.Services.AddSingleton<IAQConnectivity, RandomConnectedConnectivity>();


await builder.Build().RunAsync();
