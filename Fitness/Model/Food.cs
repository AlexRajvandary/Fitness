using System;

namespace Fitness.Model
{
    public sealed class Food
    {
        public Food(string name, EnergeticValue energeticValue)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(energeticValue == null)
            {
                throw new ArgumentNullException(nameof(energeticValue));
            }

            Name = name;
            EnergeticValue = energeticValue;
        }

        public string Name { get; }

        public EnergeticValue EnergeticValue { get; }

        public double Weight { get; }

        public double TotalCallories => EnergeticValue.Callories * Weight / 100;

        public override string ToString() => Name;
    }
}
