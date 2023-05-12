using BDD.Interfaces;
using OpenQA.Selenium;

namespace BDD.AppiumFramework;

public class AppiumFrameworkElement : IPageElement
{
    private readonly IWebElement _webElement;

    public AppiumFrameworkElement(IWebElement webElement)
    {
        _webElement = webElement;
    }

    public string Text => _webElement.Text;

    public bool Displayed => _webElement.Displayed;

    public bool Enabled => _webElement.Enabled;

    public void Click()
    {
        _webElement.Click();
    }

    public void SendKeys(string text)
    {
        _webElement.SendKeys(text);
    }
}