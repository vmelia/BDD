using BDD.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace BDD.AppiumFramework;

public class AppiumFrameworkDriver : IDriver
{
    private const string _androidPath = "com.companyname.mauiapp2:id/";
    private readonly bool _isAndroid;
    private readonly AppiumDriver<IWebElement> _driver;

    public AppiumFrameworkDriver(ISettingsProvider settingsProvider)
    {
        _isAndroid = settingsProvider.IsAndroid;

        var appiumOptions = new AppiumOptions();
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, settingsProvider.FrameworkSettings["platformName"]);
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, settingsProvider.FrameworkSettings["platformVersion"]);
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, settingsProvider.FrameworkSettings["deviceName"]);
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, settingsProvider.FrameworkSettings["app"]);
        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, settingsProvider.FrameworkSettings["automationName"]);

        _ = int.TryParse(settingsProvider.GeneralSettings["connectionTimeOutInSeconds"],
            out var connectionTimeOutInSeconds);

        if (_isAndroid)
        {
            _driver = new AndroidDriver<IWebElement>(appiumOptions, TimeSpan.FromSeconds(connectionTimeOutInSeconds));
        }
        else
        {
            _driver = new IOSDriver<IWebElement>(appiumOptions, TimeSpan.FromSeconds(connectionTimeOutInSeconds));
        }
    }

    public IPageElement FindElementById(string id)
    {
        var webElement = _isAndroid ? _driver.FindElementById($"{_androidPath}{id}") : _driver.FindElementByAccessibilityId(id);
        return new AppiumFrameworkElement(webElement);
    }
}