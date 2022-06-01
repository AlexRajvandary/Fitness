using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public sealed class EnergeticValue
    {
        public EnergeticValue(double callories)
        {
            Callories = callories;
        }

        public EnergeticValue(ushort proteins, ushort fats, ushort carbohydrates)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Callories = CalculateCallories(proteins, fats, carbohydrates);
        }

        public ushort Proteins { get; }

        public ushort Fats { get; }

        public ushort Carbohydrates { get; }

        public double Callories { get; }

        private double CalculateCallories(ushort proteins, ushort fats, ushort carbohydrates) => proteins * 4.22 + fats * 9.29 + carbohydrates * 4.22;
    }
}
