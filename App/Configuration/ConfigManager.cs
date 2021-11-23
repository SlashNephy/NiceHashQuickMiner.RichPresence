using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;

namespace NiceHashQuickMinerRichPresence.Configuration
{
    public sealed class ConfigManager : IConfigManager
    {
        private static StorageFolder Folder => ApplicationData.Current.LocalFolder;
        private const string filename = "config.json";

        private readonly Task initTask;
        private Config? config;
        public Config Config
        {
            get
            {
                initTask.Wait();
                return config ?? throw new AggregateException("Config is not loaded yet.");
            }
        }

        public ConfigManager()
        {
            initTask = Task.Run(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            var instance = await LoadConfigAsync() ?? new Config();

            lock (this)
            {
                config = instance;
            }
        }

        public async Task SaveAsync()
        {
            Config? instance;
            lock (this)
            {
                instance = config;
            }

            await SaveConfigAsync(instance);
        }

        private static async Task<Config?> LoadConfigAsync()
        {
            try
            {
                var file = await Folder.GetFileAsync(filename);
                var content = await FileIO.ReadTextAsync(file);
                return JsonConvert.DeserializeObject<Config?>(content);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        private static async Task SaveConfigAsync(Config? config)
        {
            if (config == null)
            {
                return;
            }

            StorageFile file;
            try
            {
                
                file = await Folder.GetFileAsync(filename);
            }
            catch (FileNotFoundException)
            {
                file = await Folder.CreateFileAsync(filename);
            }

            var content = JsonConvert.SerializeObject(config);
            await FileIO.WriteTextAsync(file, content);
        }

        public async Task LaunchFileAsync()
        {
            try
            {

                var file = await Folder.GetFileAsync(filename);
                await Launcher.LaunchFileAsync(file);
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}
