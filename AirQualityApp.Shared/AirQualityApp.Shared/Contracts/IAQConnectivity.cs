﻿namespace AirQualityApp.Shared.Contracts;

/// <summary>
/// Defines an interface for components to check current network conditions
/// and changes to those conditions.
/// </summary>
public interface IAQConnectivity
{
    Task<bool> GetIsConnectedAsync();
    event EventHandler? ConnectivityChanged;
}
