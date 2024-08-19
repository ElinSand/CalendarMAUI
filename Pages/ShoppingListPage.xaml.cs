using CalendarApp.ViewModels;

namespace CalendarApp.Pages;

public partial class ShoppingListPage : ContentPage
{
	public ShoppingListPage()
	{
		InitializeComponent();

        BindingContext = ShoppingListViewModel.Instance;
	}
}