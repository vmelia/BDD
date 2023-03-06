using OpenQA.Selenium;
using SpecFlowTests.Configuration;
using SpecFlowTests.Drivers;

namespace SpecFlowTests.Pages;

public class MainPage : PageBase
{
    protected const string LogoId = "Logo";
    protected const string EnterTaskId = "EnterTask";
    protected const string AddId = "Add";
    protected const string TaskListId = "TaskList";

    public MainPage(DriverProvider driverProvider, ConfigProvider configProvider) : base(driverProvider, configProvider) { }

    public override bool Displayed => Logo.Displayed;

    public IWebElement Logo => FindElementById(LogoId);
    public IWebElement EnterTask => FindElementById(EnterTaskId);
    public IWebElement Add => FindElementById(AddId);
    public IWebElement TaskList => FindElementById(TaskListId);
    public IWebElement TaskListItem => FindChildElementByClassName(TaskList, ("android.widget.TextView"));
}