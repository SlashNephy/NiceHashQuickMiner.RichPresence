using NiceHashQuickMinerRichPresence.Excavator;
using System.Linq;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public class TotalEfficient : IExcavatorVariable
{
    public string Key => "total_efficient";
    public string Description => "Average of all GPUs power effient (kH/J).";

    public string GetText(ExcavatorWorkersResponse workers, ExcavatorDevicesCudaResponse devices)
    {
        var hashrate = workers.workers.Sum(worker => worker.algorithms.Sum(algorithm => algorithm.speed)) / 1000;
        var usage = devices.devices.Sum(device => device.gpu_power_usage);
        var efficient = hashrate / usage;
        return efficient.ToString("F1");
    }
}
