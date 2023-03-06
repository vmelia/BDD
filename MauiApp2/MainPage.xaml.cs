using MauiApp2.ViewModel;

namespace MauiApp2;

public partial class MainPage
{

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}