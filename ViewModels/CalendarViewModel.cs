using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalendarApp.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private static CalendarViewModel _instance;
        public static CalendarViewModel Instance => _instance ??= new CalendarViewModel();

        private ObservableCollection<CalendarEvent> _events;
        private CalendarEvent _newEvent;

        public ObservableCollection<CalendarEvent> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged();
            }
        }

        public CalendarEvent NewEvent
        {
            get => _newEvent;
            set
            {
                _newEvent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEventCommand { get; }
        public ICommand RemoveEventCommand { get; }

        private CalendarViewModel()
        {
            Events = new ObservableCollection<CalendarEvent>();
            NewEvent = new CalendarEvent
            {
                Date = DateTime.Today
                //Time = DateTime.Now.TimeOfDay,
                //Description = string.Empty
            };
            AddEventCommand = new Command(AddEvent);
            RemoveEventCommand = new Command<CalendarEvent>(RemoveEvent);
        }

        private void AddEvent()
        {
            if (NewEvent != null && !string.IsNullOrWhiteSpace(NewEvent.Description))
            {
                Events.Add(NewEvent);
                NewEvent = new CalendarEvent
                {
                    Date = DateTime.Today
                };
                OnPropertyChanged(nameof(NewEvent));
            }
        }

        private void RemoveEvent(CalendarEvent calendarEvent)
        {
            if (Events.Contains(calendarEvent))
            {
                Events.Remove(calendarEvent);
            }
        }
    }

    public class CalendarEvent
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }



        public string DescriptionWithDateTime
        {
            get
            {
                return $"{Description} - {Date:yyyy-MM-dd} - Tid: {Time:hh\\:mm}";
            }
        }



       
    }
}
