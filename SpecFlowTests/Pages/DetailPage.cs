using BDD.Interfaces;

namespace SpecFlowTests.Pages;

// ReSharper disable once UnusedMember.Global
public class DetailPage : PageBase
{
    protected const string TaskNameId = "Task name";
    //protected const string GoBackId = "Go back";

    public DetailPage(IDriverProvider driverProvider) : base(driverProvider) { }

    public override bool Displayed => TaskName.Displayed;

    public IPageElement TaskName => Driver!.FindElementById(TaskNameId);
    //public IWebElement GoBack => FindElement(GoBackId);
}