using System.Text.Json.Serialization;

namespace NiceHashQuickMinerRichPresence.Configuration;

public class Config
{
    public string ExcavatorApiHost { get; set; } = "localhost";
    public double ExcavatorApiPort { get; set; } = 18000;
    public string ExcavatorApiAuth { get; set; } = string.Empty;

    public string DiscordApplicationId { get; set; } = "912308386899587103";
    public string DetailsTemplate { get; set; } = "{total_hashrate} MH/s";
    public string StateTemplate { get; set; } = "{total_power_usage} W ({total_efficient} kH/J)";
    public bool EnableLargeImage { get; set; } = true;
    public string LargeImageTextTemplate { get; set; } = "Active algo: {algorithm_name}";
    public bool EnableSmallImage { get; set; } = false;
    public string SmallImageTextTemplate { get; set; } = string.Empty;
    public double UpdateIntervalMs { get; set; } = 3000;
}
