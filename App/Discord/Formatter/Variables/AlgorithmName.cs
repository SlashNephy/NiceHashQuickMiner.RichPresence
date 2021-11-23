using NiceHashQuickMinerRichPresence.Excavator;
using System.Linq;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public class AlgorithmName : IExcavatorWorkersVariable
{
    public string Key => "algorithm_name";
    public string Description => "Active algorithm names";

    public string GetText(ExcavatorWorkersResponse workers)
    {
        var algorithms = workers.workers.Select(worker => worker.algorithms.Select(algorithm => algorithm.name))
            .SelectMany(i => i)
            .Distinct();
        return string.Join(", ", algorithms);
    }
}
