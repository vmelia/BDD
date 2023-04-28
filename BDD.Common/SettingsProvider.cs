using BDD.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BDD.Common;

public class SettingsProvider : ISettingsProvider
{
    public SettingsProvider()
    {
        var directory = Directory.GetCurrentDirectory();
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        FrameworkSettings = configurationBuilder.GetRequiredSection("FrameworkSettings").GetChildren().ToDictionary(x => x.Key, x => x.Value!.ToString());
        GeneralSettings = configurationBuilder.GetRequiredSection("GeneralSettings").GetChildren().ToDictionary(x => x.Key, x => x.Value!.ToString());
    }

    public IDictionary<string, string> FrameworkSettings { get; }

    public IDictionary<string, string> GeneralSettings { get; }

    public bool IsAndroid => FrameworkSettings["platformName"] == "Android";
}