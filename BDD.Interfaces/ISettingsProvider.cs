namespace BDD.Interfaces;

public interface ISettingsProvider
{
    public IDictionary<string, string> FrameworkSettings { get; }
    public IDictionary<string, string> GeneralSettings { get; }

    public bool IsAndroid { get; }
}