using CalendarApp.ViewModels;
using Microsoft.Maui.Controls;

namespace CalendarApp.Pages;

public partial class RecipesPage : ContentPage
{
	public RecipesPage()
	{
		InitializeComponent();
        BindingContext = new RecipesViewModel();
    }
}