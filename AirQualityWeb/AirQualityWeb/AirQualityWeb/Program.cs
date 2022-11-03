using AirQualityApp.Shared.Contracts;
using AirQualityApp.Shared.Data;
using AirQualityApp.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<AQIDataService>();

// Pick one of these network connectivity options:

// 1. Use the device's current connectivity
// (For Blazor Server, the server must be connected to the internet!)

// 2. Assume connectivity is always available
builder.Services.AddSingleton<IAQConnectivity, AlwaysConnectedConnectivity>();

// 3. Randomly change between connected and disconnected
//builder.Services.AddSingleton<IAQConnectivity, RandomConnectedConnectivity>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
