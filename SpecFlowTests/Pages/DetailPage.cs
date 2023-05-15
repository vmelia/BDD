using BDD.Interfaces;

namespace SpecFlowTests.Pages;

public abstract class DetailPage : PageBase
{
    protected const string TaskNameId = "Task name";
    //protected const string GoBackId = "Go back";

    protected DetailPage(IDriverProvider driverProvider) : base(driverProvider) { }

    public override bool Displayed => TaskName.Displayed;

    public virtual IPageElement TaskName => Driver!.FindElementById(TaskNameId);
    //public IWebElement GoBack => FindElement(GoBackId);
}

public class DetailPageAndroid : DetailPage
{
    public DetailPageAndroid(IDriverProvider driverProvider) : base(driverProvider) { }
}

public class DetailPageIos : DetailPage
{
    public DetailPageIos(IDriverProvider driverProvider) : base(driverProvider) { }
}