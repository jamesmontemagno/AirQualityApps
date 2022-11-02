namespace AirQualityApp.Shared.Data;

/// <summary>
/// Implements the <see cref="IAQConnectivity"/> interface to report a [not actually] random changing network state.
/// </summary>
public class RandomConnectedConnectivity : IAQConnectivity, IDisposable
{
    private readonly Timer _timer;
    private bool _isConnected;

    public RandomConnectedConnectivity()
    {
        _timer = new Timer(
            _ =>
            {
                _isConnected = !_isConnected;
                ConnectivityChanged?.Invoke(this, EventArgs.Empty);
            },
            state: null,
            dueTime: 0,
            period: 5_000);
    }

    public Task<bool> GetIsConnectedAsync() => Task.FromResult(_isConnected);

    public event EventHandler? ConnectivityChanged;

    public void Dispose()
    {
        _timer.Dispose();
    }
}
