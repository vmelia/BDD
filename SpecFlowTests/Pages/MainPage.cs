using BDD.Interfaces;

namespace SpecFlowTests.Pages;

public class MainPage : PageBase
{
    protected const string LogoId = "Logo";
    protected const string EnterTaskId = "EnterTask";
    protected const string AddId = "Add";
    protected const string TaskListId = "TaskList";

    public MainPage(IDriverProvider driverProvider) : base(driverProvider) { }

    public override bool Displayed => Logo!.Displayed;

    public IPageElement Logo => Driver!.FindElementById(LogoId);
    public IPageElement EnterTask => Driver!.FindElementById(EnterTaskId);
    public IPageElement Add => Driver!.FindElementById(AddId);
    public IPageElement TaskList => Driver!.FindElementById(TaskListId);
}