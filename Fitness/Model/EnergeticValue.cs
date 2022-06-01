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

        public EnergeticValue(int proteins, int fats, int carbohydrates)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Callories = CalculateCallories(proteins, fats, carbohydrates);
        }

        public int Proteins { get; }

        public int Fats { get; }

        public int Carbohydrates { get; }

        public double Callories { get; }

        private double CalculateCallories(int proteins, int fats, int carbohydrates) => proteins * 4.22 + fats * 9.29 + carbohydrates * 4.22;

        public static EnergeticValue operator +(EnergeticValue left, EnergeticValue right) => new EnergeticValue(left.Proteins + right.Proteins, left.Fats + right.Fats, left.Carbohydrates + right.Carbohydrates);
    }
}
