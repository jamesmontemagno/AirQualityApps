using AirQualityApp.Shared.Data;
using Microsoft.JSInterop;

namespace AirQualityHybrid;

/// <summary>
/// Implements the <see cref="IAQConnectivity"/> interface to report the browser's network state.
/// </summary>
public class JSInteropNetworkConnectivity : IAQConnectivity
{
    private readonly IJSRuntime _jsRuntime;

    public JSInteropNetworkConnectivity(IJSRuntime jsRuntime)
    {
        //jsRuntime.InvokeVoidAsync("alert", "hi");
        _jsRuntime = jsRuntime;
        JSInvokeMethods.OnlineStatusChanged += (_, __) => ConnectivityChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task<bool> GetIsConnectedAsync() =>
        await _jsRuntime.InvokeAsync<bool>("window.getOnLineStatus");

    public event EventHandler? ConnectivityChanged;
}

public static class JSInvokeMethods
{
    public static event EventHandler? OnlineStatusChanged;

    [JSInvokable]
    public static void GoingOnline()
    {
        OnlineStatusChanged?.Invoke(null, EventArgs.Empty);
    }

    [JSInvokable]
    public static void GoingOffline()
    {
        OnlineStatusChanged?.Invoke(null, EventArgs.Empty);
    }
}
