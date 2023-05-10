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
        AndroidSettings = new AppSettings(configurationBuilder.GetRequiredSection(nameof(AndroidSettings)).GetChildren().ToDictionary(x => x.Key, y => y.Value!));
        IosSettings = new AppSettings(configurationBuilder.GetRequiredSection(nameof(IosSettings)).GetChildren().ToDictionary(x => x.Key, y => y.Value!));
    }

    public AppSettings FrameworkSettings { get; }
    public AppSettings AndroidSettings { get; }
    public AppSettings IosSettings { get; }

    public bool IsAndroid => FrameworkSettings["platformName"] == "Android";
    public bool IsIos => FrameworkSettings["platformName"] == "iOS";
}