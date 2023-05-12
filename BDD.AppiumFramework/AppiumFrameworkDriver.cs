using BDD.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace BDD.AppiumFramework;

public class AppiumFrameworkDriver : IDriver
{
    private readonly ISettingsProvider _settingsProvider;
    private const string _androidPath = "com.companyname.mauiapp2:id/";
    private readonly AppiumDriver<IWebElement> _driver;

    public AppiumFrameworkDriver(ISettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
        _ = int.TryParse(settingsProvider.FrameworkSettings["ConnectionTimeOutInSeconds"], out var connectionTimeOutInSeconds);

        var appiumOptions = new AppiumOptions();
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, settingsProvider.FrameworkSettings["PlatformName"]);

        if (settingsProvider.IsAndroid)
        {
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, settingsProvider.AndroidSettings["AutomationName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, settingsProvider.AndroidSettings["App"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, settingsProvider.AndroidSettings["PlatformVersion"]);

            _driver = new AndroidDriver<IWebElement>(appiumOptions, TimeSpan.FromSeconds(connectionTimeOutInSeconds));
        }
        else if (settingsProvider.IsIos)
        {
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, settingsProvider.IosSettings["AutomationName"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, settingsProvider.IosSettings["App"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, settingsProvider.IosSettings["PlatformVersion"]);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, settingsProvider.IosSettings["DeviceName"]);

            _driver = new IOSDriver<IWebElement>(appiumOptions, TimeSpan.FromSeconds(connectionTimeOutInSeconds));
        }
        else
        {
            throw new InvalidOperationException("Invalid platform");
        }
    }

    public IPageElement FindElementById(string id)
    {
        if (_settingsProvider.IsAndroid)
        {
            var webElement = _driver.FindElementById($"{_androidPath}{id}");
            return new AppiumFrameworkElement(webElement);
        }
        if (_settingsProvider.IsIos)
        {
            var webElement = _driver.FindElementByAccessibilityId(id);
            return new AppiumFrameworkElement(webElement);
        }

        throw new InvalidOperationException("Invalid platform");
    }
}