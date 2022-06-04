using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Fitness.Model
{
    public sealed class FitnessDay : INotifyPropertyChanged
    {
        public FitnessDay(DateOnly date)
        {
            Date = date;
            Foods = new ObservableCollection<Food>();
            Activities = new ObservableCollection<Activity>();

            Foods.CollectionChanged += Foods_CollectionChanged;
            Activities.CollectionChanged += Activities_CollectionChanged;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
      
        public DateOnly Date { get; }

        public ObservableCollection<Activity>? Activities { get; set; }

        public ObservableCollection<Food>? Foods { get; set; }

        public EnergeticValue? TotalEnergeticValue => Foods is not null && Activities.Count > 0 ? Foods.Count > 1 ? Foods.Select(food => food.EnergeticValue).Aggregate((first, next)=> first + next) : Foods.FirstOrDefault()?.EnergeticValue : null;

        public double TotalCalloriesConsumption => Activities is not null && Activities.Count > 0 ? Activities.Sum(activity => activity.TotalCalloriesConsumption) : 0;

        public double TotalCalloriesGet => TotalEnergeticValue?.Callories ?? 0;

        public override string ToString()
        {
            return Date.ToString();
        }

        private void Activities_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(TotalCalloriesConsumption));

        private void Foods_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => OnPropertyChanged(nameof(TotalCalloriesGet));

        private void OnPropertyChanged([CallerMemberName] string? propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
