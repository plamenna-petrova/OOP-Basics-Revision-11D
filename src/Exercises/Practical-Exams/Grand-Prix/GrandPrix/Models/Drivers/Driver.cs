using System;
using System.Collections.Generic;
using System.Text;
using GrandPrix.Classes;

namespace GrandPrix.Models.Drivers
{
    public class Driver
    {
        private string name;

        private float totalTime;

        private Car car;

        private float fuelConsumptionPerKm;

        private float speed;

        public Driver(string name, Car car)
        {
            Name = name;
            Car = car;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public float TotalTime
        {
            get
            {
                return totalTime;
            }

            set
            {
                totalTime = value;
            }
        }

        public Car Car
        {
            get
            {
                return car;
            }

            set
            {
                car = value;
            }
        }

        public float FuelConsumptionPerKm
        {
            get
            {
                return fuelConsumptionPerKm;
            }

            set
            {
                fuelConsumptionPerKm = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
    }
}
