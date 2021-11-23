using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Configuration;

public interface IConfigManager
{
    public Config Config { get; }

    public Task LoadAsync();
    public Task SaveAsync();
    public Task LaunchFileAsync();
}
