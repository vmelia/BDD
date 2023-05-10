namespace BDD.Interfaces;

public interface ISettingsProvider
{
    public AppSettings FrameworkSettings { get; }
    public AppSettings AndroidSettings { get; }
    public AppSettings IosSettings { get; }

    public bool IsAndroid { get; }
    public bool IsIos { get; }
}