using BDD.AppiumFramework;
using BDD.Common;
using BDD.Interfaces;
using BoDi;

namespace SpecFlowTests;

[Binding]
public class Main
{
    private readonly IObjectContainer _objectContainer;

    public Main(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void Initialize()
    {
        _objectContainer.RegisterTypeAs<SettingsProvider, ISettingsProvider>();
        _objectContainer.RegisterTypeAs<AppiumDriverProvider, IDriverProvider>();
    }
}