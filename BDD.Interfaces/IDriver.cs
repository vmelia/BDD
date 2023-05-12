namespace BDD.Interfaces;

public interface IDriver
{
    IPageElement FindElementById(string id);
    ICollection<IPageElement> FindElements(string id);
}