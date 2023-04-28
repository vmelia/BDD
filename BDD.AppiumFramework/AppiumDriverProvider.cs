using BDD.Interfaces;

namespace BDD.AppiumFramework;

public class AppiumDriverProvider : IDriverProvider
{
    private readonly ISettingsProvider _settingsProvider;

    public AppiumDriverProvider(ISettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
    }

    public IDriver CreateDriver()
    {
        return new AppiumFrameworkDriver(_settingsProvider);
    }
}