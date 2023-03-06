using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using SpecFlowTests.Configuration;

namespace SpecFlowTests.Drivers;

public class DriverProvider
{
    private readonly AppiumSettings _appiumSettings;
    private readonly AppiumOptions _appiumOptions = new();

    private readonly Dictionary<string, Func<Uri, AppiumOptions, AppiumDriver<IWebElement>>> _drivers;

    public DriverProvider(ConfigProvider configProvider)
    {
        var generalSettings = configProvider.GeneralSettings;

        _drivers = new Dictionary<string, Func<Uri, AppiumOptions, AppiumDriver<IWebElement>>>
        {
            {
                MobilePlatform.Android, (remoteAddress, options) => new AndroidDriver<IWebElement>(remoteAddress, options, TimeSpan.FromSeconds(generalSettings.ConnectionTimeOutInSeconds))
            },
            {
                MobilePlatform.IOS, (remoteAddress, options) => new IOSDriver<IWebElement>(remoteAddress, options, TimeSpan.FromSeconds(generalSettings.ConnectionTimeOutInSeconds))
            }
        };


        _appiumSettings = configProvider.AppiumSettings;

        _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, _appiumSettings.PlatformName);
        _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, _appiumSettings.PlatformVersion);
        _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, _appiumSettings.DeviceName);
        _appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, _appiumSettings.App);
        _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, _appiumSettings.AutomationName);

    }

    public AppiumDriver<IWebElement> AppiumDriver => _drivers[_appiumSettings.PlatformName].Invoke(_appiumSettings.RemoteServerAddress, _appiumOptions);
}