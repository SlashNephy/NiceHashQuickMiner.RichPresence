using NiceHashQuickMinerRichPresence.Excavator;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public interface IExcavatorDevicesCudaVariable : IFormatVariable
{
    public string GetText(ExcavatorDevicesCudaResponse devices);
}
