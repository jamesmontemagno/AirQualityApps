namespace AirQualityApp.Shared.Data;

/// <summary>
/// Defines an interface for components to check current network conditions
/// and changes to those conditions.
/// </summary>
public interface IAQConnectivity
{
    bool IsConnected { get; }
    event EventHandler? ConnectivityChanged;
}
