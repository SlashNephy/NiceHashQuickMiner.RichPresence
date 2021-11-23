using NiceHashQuickMinerRichPresence.Excavator;
using System.Linq;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public class TotalPowerUsage : IExcavatorDevicesCudaVariable
{
    public string Key => "total_power_usage";
    public string Description => "All GPUs power usage (W).";

    public string GetText(ExcavatorDevicesCudaResponse devices)
    {
        var usage = devices.devices.Sum(device => device.gpu_power_usage);
        return usage.ToString("F1");
    }
}
