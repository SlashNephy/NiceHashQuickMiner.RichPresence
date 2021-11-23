namespace NiceHashQuickMinerRichPresence.Tasks;

public interface IBackgroundTaskRunner
{
    public void Run();
    public void Cancel();
}
