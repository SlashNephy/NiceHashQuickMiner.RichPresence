using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Tasks;

public interface IBackgroundTask
{
    public Task Run(CancellationToken token);
}
