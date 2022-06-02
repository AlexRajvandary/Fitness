using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Fitness.Model;

namespace Fitness.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FitnessDay currentFitnessDay;

        public MainViewModel()
        {
            ExistingActivities = new ObservableCollection<Activity>();
            ExistingFoods = new ObservableCollection<Food>();
            FitnessDays = new ObservableCollection<FitnessDay>(GetDays(DateOnly.FromDateTime(DateTime.Now.Date), DateOnly.FromDateTime(DateTime.Now.AddDays(365).Date)));
            CurrentFitnessDay = FitnessDays.FirstOrDefault();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Activity> ExistingActivities { get; set; }

        public ObservableCollection<Food> ExistingFoods { get; set; }

        public FitnessDay CurrentFitnessDay
        {
            get => currentFitnessDay;
            set
            {
                if(currentFitnessDay != value)
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
