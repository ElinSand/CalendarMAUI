using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarApp.ViewModels
{
    public class ShoppingListViewModel : BaseViewModel
    {
        private static ShoppingListViewModel _instance; 
        public static ShoppingListViewModel Instance => _instance ??= new ShoppingListViewModel(); 


        private ObservableCollection<string> _items;
        private string _newItem;

        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string NewItem
        {
            get => _newItem;
            set
            {
                _newItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }

        private ShoppingListViewModel()
        {
            Items = new ObservableCollection<string>();
            AddItemCommand = new Command(AddItem);
            RemoveItemCommand = new Command<string>(RemoveItem);
        }

        private void AddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                Items.Add(NewItem);
                NewItem = string.Empty; // Tömmer textrutan efter att ett objekt har lagts till
            }
        }

        private void RemoveItem(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }





       
    }
}
