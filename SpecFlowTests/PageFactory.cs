using BDD.Interfaces;
using SpecFlowTests.Pages;

namespace SpecFlowTests;

public class PageFactory
{
    private readonly IDriverProvider _driverProvider;
    private readonly bool _isAndroid;
    private readonly bool _isIos;

    public PageFactory(ISettingsProvider settingsProvider, IDriverProvider driverProvider)
    {
        _driverProvider = driverProvider;
        _isAndroid = settingsProvider.IsAndroid;
        _isIos = settingsProvider.IsIos;
    }

    public PageBase CreatePage(string pageName)
    {
        return pageName switch
        {
            nameof(MainPage) when _isAndroid => new MainPageAndroid(_driverProvider),
            nameof(MainPage) when _isIos => new MainPageIos(_driverProvider),
            nameof(DetailPage) when _isAndroid => new DetailPageAndroid(_driverProvider),
            nameof(DetailPage) when _isIos => new DetailPageIos(_driverProvider),
            _ => throw new InvalidOperationException($"Invalid page name: {pageName}")
        };
    }
}