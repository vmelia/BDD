namespace BDD.Interfaces;

public interface IPageElement
{
    string Text { get; }

    bool Displayed { get; }
    bool Enabled { get; }

    void Click();
    void SendKeys(string text);
}