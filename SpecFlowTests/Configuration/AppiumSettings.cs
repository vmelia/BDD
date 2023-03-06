namespace SpecFlowTests.Configuration;

public class AppiumSettings
{
    public Uri RemoteServerAddress { get; set; } = new ("c:/temp");
    public string PlatformName { get; set; } = string.Empty;
    public string PlatformVersion { get; set; } = string.Empty;
    public string DeviceName { get; set; } = string.Empty;
    public string App { get; set; } = string.Empty;
    public string AutomationName { get; set; } = string.Empty;
}