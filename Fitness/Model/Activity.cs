using System;

namespace Fitness.Model
{
    public class Activity
    {
        public Activity(string name, TimeSpan duration, double calloriesConsumption)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(duration <= TimeSpan.Zero)
            {
                throw new ArgumentException("Duration cannot be less than zero.", nameof(duration));
            }

            if(calloriesConsumption <= 0)
            {
                throw new ArgumentException("Consumption cannot be less or equal to zero.", nameof(calloriesConsumption));
            }

            Name = name;
            Duration = duration;
        }

        public string Name { get; }

        public TimeSpan Duration { get; }

        /// <summary>
        /// Callories consumption per hour.
        /// </summary>
        public double CalloriesConsumption { get; }

        public double TotalCalloriesConsumption => CalloriesConsumption * Duration.TotalHours;
    }
}
