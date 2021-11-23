using NiceHashQuickMinerRichPresence.Excavator;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public interface IExcavatorVariable : IFormatVariable
{
    public string GetText(ExcavatorWorkersResponse workers, ExcavatorDevicesCudaResponse devices);
}
