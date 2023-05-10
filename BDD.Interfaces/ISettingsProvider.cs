namespace BDD.Interfaces;

public interface ISettingsProvider
{
    public AppSettings FrameworkSettings { get; }
    public AppSettings GeneralSettings { get; }

    public bool IsAndroid { get; }
}