using BDD.Interfaces;

namespace SpecFlowTests.Pages;

public abstract class PageBase
{
    protected const string AndroidPath = "com.companyname.mauiapp2:id/";

    protected readonly IDriver? Driver;

    protected PageBase(IDriverProvider driverProvider)
    {
        Driver = driverProvider.CreateDriver();
    }

    public abstract bool Displayed { get; }
}