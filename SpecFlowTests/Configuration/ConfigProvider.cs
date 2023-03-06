using Microsoft.Extensions.Configuration;

namespace SpecFlowTests.Configuration;

public class ConfigProvider
{
    public ConfigProvider()
    {
        var directory = Directory.GetCurrentDirectory();
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var appiumSettingsSection = configurationBuilder.GetRequiredSection("AppiumSettings");
        AppiumSettings = appiumSettingsSection.Get<AppiumSettings>() ?? new AppiumSettings();
        var generalSettingsSection = configurationBuilder.GetRequiredSection("GeneralSettings");
        GeneralSettings = generalSettingsSection.Get<GeneralSettings>() ?? new GeneralSettings();
    }

    public AppiumSettings AppiumSettings { get; }
    public GeneralSettings GeneralSettings { get; }

    public bool IsAndroid => AppiumSettings.PlatformName == "Android";
}