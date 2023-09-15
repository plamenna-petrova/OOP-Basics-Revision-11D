using GrandPrix.Classes.Tires;
using System;

namespace GrandPrix.Classes
{
    public class Car
    {
        private const int FuelAmountMaxCapacity = 160;

        private int hp;

        private double fuelAmount;

        private Tyre tyre;

        public Car(int hp, double fuelAmount, Tyre tyre)
        {
            this.hp = hp;
            this.fuelAmount = fuelAmount;
            this.tyre = tyre;
        }

        public int HP
        {
            get
            {
                return this.hp;
            }

            set
            {
                this.hp = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }

            set
            {
                if (value > FuelAmountMaxCapacity)
                {
                    this.fuelAmount = FuelAmountMaxCapacity;
                }
                else
                {
                    this.fuelAmount = value;
                }
            }
        }

        public Tyre Tyre
        {
            get
            {
                return this.tyre;
            }

            set
            {
                this.tyre = value;
            }
        }
    }
}
