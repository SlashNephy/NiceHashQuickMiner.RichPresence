using Newtonsoft.Json;
using NiceHashQuickMinerRichPresence.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Excavator;

public sealed class ExcavatorApiClient : IExcavatorApiClient
{
    private readonly IConfigManager configManager;
    private readonly HttpClient httpClient = new();

    public ExcavatorApiClient(IConfigManager configManager)
    {
        this.configManager = configManager;
    }

    public async Task<ExcavatorWorkersResponse> GetWorkers(CancellationToken token)
    {
        var url = $"http://{configManager.Config.ExcavatorApiHost}:{configManager.Config.ExcavatorApiPort}/workers";
        if (!string.IsNullOrWhiteSpace(configManager.Config.ExcavatorApiAuth))
        {
            url += $"?auth={configManager.Config.ExcavatorApiAuth}";
        }

        var content = await httpClient.GetStringAsync(url, token);
        return JsonConvert.DeserializeObject<ExcavatorWorkersResponse>(content);
    }

    public async Task<ExcavatorDevicesCudaResponse> GetDevicesCuda(CancellationToken token)
    {
        var url = $"http://{configManager.Config.ExcavatorApiHost}:{configManager.Config.ExcavatorApiPort}/devices_cuda";
        if (!string.IsNullOrWhiteSpace(configManager.Config.ExcavatorApiAuth))
        {
            url += $"?auth={configManager.Config.ExcavatorApiAuth}";
        }

        var content = await httpClient.GetStringAsync(url, token);
        return JsonConvert.DeserializeObject<ExcavatorDevicesCudaResponse>(content);
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}
