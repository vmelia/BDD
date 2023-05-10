using BDD.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BDD.Common;

public class SettingsProvider : ISettingsProvider
{
    private const string _settingsFile = "appsettings.json";

    public SettingsProvider()
    {
        var directory = Directory.GetCurrentDirectory();
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile(_settingsFile, false, true)
            .Build();

        FrameworkSettings = new AppSettings(configurationBuilder.GetRequiredSection(nameof(FrameworkSettings)).GetChildren().ToDictionary(x => x.Key, y => y.Value!));
        GeneralSettings = new AppSettings(configurationBuilder.GetRequiredSection(nameof(GeneralSettings)).GetChildren().ToDictionary(x => x.Key, y => y.Value!));
    }

    public AppSettings FrameworkSettings { get; }

    public AppSettings GeneralSettings { get; }

    public bool IsAndroid => FrameworkSettings["platformName"] == "Android";
}