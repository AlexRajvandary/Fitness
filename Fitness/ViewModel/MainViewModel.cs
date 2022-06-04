using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Fitness.Model;
using System.Windows.Input;

namespace Fitness.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string activityName;
        private string activityDuration;
        private string activityCallories;
        private ICommand addActivity;
        private ICommand clear;
        private FitnessDay currentFitnessDay;

        public MainViewModel()
        {
            ExistingActivities = new ObservableCollection<Activity>();
            ExistingFoods = new ObservableCollection<Food>();
            FitnessDays = new ObservableCollection<FitnessDay>(GetDays(DateOnly.FromDateTime(DateTime.Now.Date), DateOnly.FromDateTime(DateTime.Now.AddDays(365).Date)));
            CurrentFitnessDay = FitnessDays.FirstOrDefault();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ActivityCallories
        {
            get => activityCallories;
            set
            {
                if (activityCallories != value)
                {
                    activityCallories = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ActivityDuration
        {
            get => activityDuration;
            set
            {
                if (ActivityDuration != value)
                {
                    activityDuration = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ActivityName
        {
            get => activityName;
            set
            {
                if (activityName != value)
                {
                    activityName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddActivity => addActivity ??= new RelayCommand(() =>
        {
            if (ActivityCallories != null && ActivityDuration != null && ActivityName != null)
            {
                if(!double.TryParse(ActivityDuration, out var duration))
                {
                    return;
                }

                if (!double.TryParse(ActivityCallories, out var callories))
                {
                    return;
                }

                CurrentFitnessDay?.Activities?.Add(new Activity(ActivityName, TimeSpan.FromHours(duration), callories));
            }

            Clear.Execute(null);
        });

        public ICommand Clear => clear ??= new RelayCommand(() =>
        {
            ActivityName = null;
            ActivityDuration = null;
            ActivityCallories = null;
        });

        public ObservableCollection<Activity> ExistingActivities { get; set; }

        public ObservableCollection<Food> ExistingFoods { get; set; }

        public FitnessDay CurrentFitnessDay
        {
            get => currentFitnessDay;
            set
            {
                if (currentFitnessDay != value)
                {
                    currentFitnessDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<FitnessDay> FitnessDays { get; set; }

        private List<FitnessDay> GetDays(DateOnly start, DateOnly end)
        {
            var days = new List<FitnessDay>();
            var curDay = start;
            while (curDay <= end)
            {
                days.Add(new FitnessDay(curDay));
                curDay = curDay.AddDays(1);
            }

            return days;
        }

        private void OnPropertyChanged([CallerMemberName] string? propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
