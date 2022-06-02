using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public sealed class FitnessDay
    {
        public FitnessDay(DateOnly date)
        {
            Date = date;
        }

        public DateOnly Date { get; }

        public List<Activity>? Activities { get; set; }

        public List<Food>? Foods { get; set; }

        public EnergeticValue? TotalEnergeticValue => Foods?.Select(food => food.EnergeticValue).Aggregate((first, next)=> first + next);

        public double TotalCalloriesConsumption => Activities?.Sum(activity => activity.TotalCalloriesConsumption) ?? 0;

        public double TotalCalloriesGet => TotalEnergeticValue?.Callories ?? 0;

        public override string ToString()
        {
            return Date.ToString();
        }
    }
}
