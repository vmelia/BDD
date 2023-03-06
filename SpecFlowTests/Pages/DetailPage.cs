using OpenQA.Selenium;
using SpecFlowTests.Configuration;
using SpecFlowTests.Drivers;

namespace SpecFlowTests.Pages;

// ReSharper disable once UnusedMember.Global
public class DetailPage : PageBase
{
    protected const string TaskNameId = "Task name";
    //protected const string GoBackId = "Go back";

    public DetailPage(DriverProvider driverProvider, ConfigProvider configProvider) : base(driverProvider, configProvider) { }

    public override bool Displayed => TaskName.Displayed;

    public IWebElement TaskName => FindElementById(TaskNameId);
    //public IWebElement GoBack => FindElement(GoBackId);
}