using AirQualityApp.Shared.Contracts;
using AirQualityApp.Shared.Data;

namespace AirQualityHybrid.Services;

/// <summary>
/// Implements the <see cref="IAQConnectivity"/> interface to report the device's network state.
/// </summary>
public class MauiEssentialsConnectivity : IAQConnectivity
{
    private readonly IConnectivity _mauiConnectivity;

    public MauiEssentialsConnectivity(IConnectivity mauiConnectivity)
    {
        _mauiConnectivity = mauiConnectivity;
        _mauiConnectivity.ConnectivityChanged += (s, e) =>
        {
            ConnectivityChanged?.Invoke(this, EventArgs.Empty);
        };
    }

    public Task<bool> GetIsConnectedAsync() => Task.FromResult(_mauiConnectivity.NetworkAccess == NetworkAccess.Internet);

    public event EventHandler ConnectivityChanged;
}
