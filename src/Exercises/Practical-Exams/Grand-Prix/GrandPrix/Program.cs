using System;

namespace GrandPrix
{
    public class Driver
    {
        private string name;

        private float totalTime;

        private Car car;

        private float fuelConsumptionPerKm;

        private float speed;

        public Driver(string name, float totalTime, Car car, float fuelConsumptionPerKm, float speed)
        {
            this.Name = name;
            this.TotalTime = totalTime;
            this.Car = car;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.Speed = speed;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public float TotalTime
        {
            get
            {
                return this.totalTime;
            }

            set
            {
                this.totalTime = value;
            }
        }

        public Car Car
        {
            get
            {
                return this.car;
            }

            set
            {
                this.car = value;
            }
        }

        public float FuelConsumptionPerKm
        {
            get
            {
                return this.fuelConsumptionPerKm;
            }

            set
            {
                this.fuelConsumptionPerKm = value;
            }
        }

        public float Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                this.speed = value;
            }
        }
    }

    public class Car
    {
        private int hp;

        private float fuelAmount;

        private Tyre tyre;

        public Car(int hp, float fuelAmount, Tyre tyre)
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

        public float FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }

            set
            {
                this.fuelAmount = value;
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

    public class Tyre
    {

    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
