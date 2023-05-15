using BDD.Interfaces;

namespace SpecFlowTests.Pages;

public abstract class MainPage : PageBase
{
    protected const string LogoId = "Logo";
    protected const string EnterTaskId = "EnterTask";
    protected const string AddId = "Add";

    protected MainPage(IDriverProvider driverProvider) : base(driverProvider) { }

    public override bool Displayed => Logo.Displayed;

    public virtual IPageElement Logo => Driver!.FindElementById(LogoId);
    public virtual IPageElement EnterTask => Driver!.FindElementById(EnterTaskId);
    public virtual IPageElement Add => Driver!.FindElementById(AddId);
    public abstract ICollection<IPageElement> TaskList { get; }
}

public class MainPageAndroid : MainPage
{
    public MainPageAndroid(IDriverProvider driverProvider) : base(driverProvider) { }

    public override ICollection<IPageElement> TaskList => Driver!.FindElements("android.widget.TextView");
}

public class MainPageIos : MainPage
{
    public MainPageIos(IDriverProvider driverProvider) : base(driverProvider) { }

    public override ICollection<IPageElement> TaskList => Driver!.FindElements("android.widget.TextView");   //ToDo: Add iOS code.
}