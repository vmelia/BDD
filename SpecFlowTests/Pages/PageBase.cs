using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SpecFlowTests.Configuration;
using SpecFlowTests.Drivers;

namespace SpecFlowTests.Pages;

public abstract class PageBase
{
    protected const string AndroidPath = "com.companyname.mauiapp2:id/";

    private readonly bool _isAndroid;
    protected readonly AppiumDriver<IWebElement> Driver;

    protected PageBase(DriverProvider driverProvider, ConfigProvider configProvider)
    {
        _isAndroid = configProvider.IsAndroid;
        Driver = driverProvider.AppiumDriver;
    }

    public abstract bool Displayed { get; }

    public IWebElement FindElementById(string id) => _isAndroid ? Driver.FindElementById($"{AndroidPath}{id}") : Driver.FindElementByAccessibilityId(id);
    
    public IWebElement FindChildElementByClassName(IWebElement parent, string className) => parent.FindElement(By.ClassName(className));
}