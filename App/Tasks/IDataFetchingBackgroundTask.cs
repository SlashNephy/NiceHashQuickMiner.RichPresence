using NiceHashQuickMinerRichPresence.Excavator;

namespace NiceHashQuickMinerRichPresence.Tasks;

public interface IDataFetchingBackgroundTask : IBackgroundTask
{
    public ExcavatorWorkersResponse? Workers { get; }
    public ExcavatorDevicesCudaResponse? Devices { get; }
}
