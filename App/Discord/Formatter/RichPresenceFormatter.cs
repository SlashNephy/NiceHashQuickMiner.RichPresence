using DiscordRPC;
using NiceHashQuickMinerRichPresence.Configuration;
using NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;
using NiceHashQuickMinerRichPresence.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter;

public sealed class RichPresenceFormatter : IRichPresenceFormatter
{
    private const string LargeImageKey = "logo";
    private const string SmallImageKey = "discord";

    public readonly List<IFormatVariable> Variables = new()
    {
        new TotalHashrate(),
        new TotalPowerUsage(),
        new TotalEfficient(),
        new NumberOfWorkers(),
        new AlgorithmName()
    };

    private readonly IConfigManager configManager;
    private readonly IDataFetchingBackgroundTask fetchingBackgroundTask;
    private readonly Timestamps timestamp = Timestamps.Now;

    public RichPresenceFormatter(IConfigManager configManager, IDataFetchingBackgroundTask fetchingBackgroundTask)
    {
        this.configManager = configManager;
        this.fetchingBackgroundTask = fetchingBackgroundTask;
    }

    public RichPresence Format()
    {
        return new RichPresence
        {
            Details = FormatDetails(),
            State = FormatState(),
            Assets = new Assets
            {
                LargeImageKey = configManager.Config.EnableLargeImage ? LargeImageKey : string.Empty,
                LargeImageText = configManager.Config.EnableLargeImage ? FormatLargeImageText() : string.Empty,
                SmallImageKey = configManager.Config.EnableSmallImage ? SmallImageKey : string.Empty,
                SmallImageText = configManager.Config.EnableSmallImage ? FormatSmallImageText() : string.Empty
            },
            Timestamps = timestamp
        };
    }

    public string FormatDetails()
    {
        if (string.IsNullOrWhiteSpace(configManager.Config.DetailsTemplate))
        {
            return string.Empty;
        }

        return FormatTemplate(configManager.Config.DetailsTemplate);
    }

    public string FormatState()
    {
        if (string.IsNullOrWhiteSpace(configManager.Config.StateTemplate))
        {
            return string.Empty;
        }

        return FormatTemplate(configManager.Config.StateTemplate);
    }

    public string FormatLargeImageText()
    {
        if (string.IsNullOrWhiteSpace(configManager.Config.LargeImageTextTemplate))
        {
            return string.Empty;
        }

        return FormatTemplate(configManager.Config.LargeImageTextTemplate);
    }

    public string FormatSmallImageText()
    {
        if (string.IsNullOrWhiteSpace(configManager.Config.SmallImageTextTemplate))
        {
            return string.Empty;
        }

        return FormatTemplate(configManager.Config.SmallImageTextTemplate);
    }

    private string FormatTemplate(string template)
    {
        var variables = Variables.Where(variable => template.Contains(variable.Key))
            .Select(variable =>
            {
                string text = variable switch
                {
                    IExcavatorWorkersVariable variable1 => fetchingBackgroundTask.Workers == null ? "-" : variable1.GetText(fetchingBackgroundTask.Workers),
                    IExcavatorDevicesCudaVariable variable2 => fetchingBackgroundTask.Devices == null ? "-" : variable2.GetText(fetchingBackgroundTask.Devices),
                    IExcavatorVariable variable3 => fetchingBackgroundTask.Workers == null || fetchingBackgroundTask.Devices == null ? "-" : variable3.GetText(fetchingBackgroundTask.Workers, fetchingBackgroundTask.Devices),
                    IGeneralVariable variable4 => variable4.GetText(),
                    _ => throw new ArgumentException($"Variable: {variable.GetType()} is not supported."),
                };
                return (variable, text);
            }).ToList();

        return variables.Aggregate(template, (x, item) =>
        {
            var (variable, text) = item;
            return x.Replace($"{{{variable.Key}}}", text);
        });
    }

    public Timestamps GetElapsed()
    {
        return timestamp;
    }
}
