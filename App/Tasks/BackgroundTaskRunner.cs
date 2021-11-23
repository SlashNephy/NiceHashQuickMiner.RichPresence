using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Tasks;

public class BackgroundTaskRunner : IBackgroundTaskRunner
{
    private readonly CancellationTokenSource cancellation = new();

    private readonly List<IBackgroundTask> tasks = new();

    public BackgroundTaskRunner(IDataFetchingBackgroundTask task1, RichPresenceBackgroundTask task2)
    {
        tasks.Add(task1);
        tasks.Add(task2);
    }

    public void Run()
    {
        Task.Run(() => RunTasks());
    }

    private void RunTasks()
    {
        var tasks = this.tasks.Select(task => task.Run(cancellation.Token)).ToArray();
        Task.WaitAll(tasks);
    }

    public void Cancel()
    {
        cancellation.Cancel();
    }
}
