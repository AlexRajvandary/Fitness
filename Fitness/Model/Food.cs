using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public sealed class Food
    {
        public Food(string name, EnergeticValue energeticValue)
        {
            Name = name;
            EnergeticValue = energeticValue;
        }

        public string Name { get; }

        public EnergeticValue EnergeticValue { get; }

        public double Weight { get; }

        public double TotalCallories => EnergeticValue.Callories * Weight / 100;
    }
}
