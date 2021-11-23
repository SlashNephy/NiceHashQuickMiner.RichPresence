using NiceHashQuickMinerRichPresence.Excavator;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public class NumberOfWorkers : IExcavatorWorkersVariable
{
    public string Key => "#workers";
    public string Description => "Number of active workers.";

    public string GetText(ExcavatorWorkersResponse workers)
    {
        return workers.workers.Count.ToString();
    }
}
