using CalendarApp.ViewModels;

namespace CalendarApp.Pages;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
        BindingContext = CalendarViewModel.Instance;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        if (BindingContext is CalendarViewModel viewModel)
        {
            // Återställer till dagens datum
            viewModel.NewEvent.Date = DateTime.Today;
        }
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedEvent = e.SelectedItem as CalendarEvent;
        if (selectedEvent != null)
        {
            // Tar bort den valda händelsen
            ((CalendarViewModel)BindingContext).RemoveEventCommand.Execute(selectedEvent);
        }
    }





}