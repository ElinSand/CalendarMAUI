using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalendarApp.Pages;
using Microsoft.Maui.Controls;

namespace CalendarApp.ViewModels
{
   
    
        public class MainViewModel : BaseViewModel
        {
            public ICommand NavigateToCalendarCommand { get; }
            public ICommand NavigateToShoppingListCommand { get; }
            public ICommand NavigateToRecipesCommand { get; }

            public MainViewModel()
            {
                NavigateToCalendarCommand = new Command(async () => await NavigateToPage(new CalendarPage()));
                NavigateToShoppingListCommand = new Command(async () => await NavigateToPage(new ShoppingListPage()));
                NavigateToRecipesCommand = new Command(async () => await NavigateToPage(new RecipesPage()));
            }

            private async Task NavigateToPage(Page page)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }
    
}
