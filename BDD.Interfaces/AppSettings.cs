namespace BDD.Interfaces;

public class AppSettings
{
    private readonly Dictionary<string, string> _settings;

    public AppSettings(Dictionary<string, string> settings)
    {
        _settings = settings;
    }

    public string this[string key]
    {
        get => _settings[key];
        set => _settings[key] = value;
    }
}