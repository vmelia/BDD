namespace MauiApp2;

public partial class AppShell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
    }
}
