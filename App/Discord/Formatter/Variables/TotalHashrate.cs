using NiceHashQuickMinerRichPresence.Excavator;
using System.Linq;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public class TotalHashrate : IExcavatorWorkersVariable
{
    public string Key => "total_hashrate";
    public string Description => "All GPUs hashrate (MH/s).";

    public string GetText(ExcavatorWorkersResponse workers)
    {
        var hashrate = workers.workers.Sum(worker => worker.algorithms.Sum(algorithm => algorithm.speed)) / 1000 / 1000;
        return hashrate.ToString("F2");
    }
}
