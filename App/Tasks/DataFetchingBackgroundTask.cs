using NiceHashQuickMinerRichPresence.Configuration;
using NiceHashQuickMinerRichPresence.Excavator;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Tasks;

public class DataFetchingBackgroundTask : IDataFetchingBackgroundTask
{
    private readonly IExcavatorApiClient excavatorApiClient;
    private readonly IConfigManager configManager;

    public ExcavatorWorkersResponse? Workers { 
        get
        {
            lastWorkersAccess = DateTime.Now;
            return workers;
        }
    }
    private ExcavatorWorkersResponse? workers;
    private DateTime lastWorkersAccess = DateTime.Now;
    private readonly object workersLock = new();

    public ExcavatorDevicesCudaResponse? Devices {
        get
        {
            lastDevicesAccess = DateTime.Now;
            return devices;
        }
    }
    private ExcavatorDevicesCudaResponse? devices;
    private DateTime lastDevicesAccess = DateTime.Now;
    private readonly object devicesLock = new();

    public DataFetchingBackgroundTask(IExcavatorApiClient excavatorApiClient, IConfigManager configManager)
    {
        this.excavatorApiClient = excavatorApiClient;
        this.configManager = configManager;
    }

    public async Task Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.WhenAll(FetchWorkers(token), FetchDevices(token));
            await Task.Delay(Convert.ToInt32(configManager.Config.UpdateIntervalMs), token);
        }
    }

    private async Task FetchWorkers(CancellationToken token)
    {
        if (DateTime.Now - lastWorkersAccess > TimeSpan.FromMilliseconds(configManager.Config.UpdateIntervalMs))
        {
            return;
        }

        try
        {
            var workers = await excavatorApiClient.GetWorkers(token);
            lock (workersLock)
            {
                this.workers = workers;
            }
        }
        catch (HttpRequestException)
        {
        }
    }

    private async Task FetchDevices(CancellationToken token)
    {
        if (DateTime.Now - lastDevicesAccess > TimeSpan.FromMilliseconds(configManager.Config.UpdateIntervalMs))
        {
            return;
        }

        try
        {
            var devices = await excavatorApiClient.GetDevicesCuda(token);
            lock (devicesLock)
            {
                this.devices = devices;
            }
        }
        catch (HttpRequestException)
        {
        }
    }
}
