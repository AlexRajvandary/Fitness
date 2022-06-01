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
        public MainViewModel()
        {
            ExistingActivities = new ObservableCollection<Activity>();
            ExistingFoods = new ObservableCollection<Food>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Activity> ExistingActivities { get; set; }

        public ObservableCollection<Food> ExistingFoods { get; set; }

        private void OnPropertyChanged([CallerMemberName]string propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
