namespace BDD.Interfaces;

public interface IPageElement
{
    bool Displayed { get; }
    bool Enabled { get; }

    void Click();
    void SendKeys(string text);
}