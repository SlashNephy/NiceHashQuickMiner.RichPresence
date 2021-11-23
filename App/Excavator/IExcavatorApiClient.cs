using System;
using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Excavator;

public interface IExcavatorApiClient : IDisposable
{
    public Task<ExcavatorWorkersResponse> GetWorkers(CancellationToken token);
    public Task<ExcavatorDevicesCudaResponse> GetDevicesCuda(CancellationToken token);
}
