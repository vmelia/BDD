using MauiApp2.ViewModel;

namespace MauiApp2;

public partial class DetailPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}