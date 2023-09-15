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

        private string failureReason;

        private bool isOvertaken;

        public Driver(string name, Car car)
        {
            Name = name;
            Car = car;
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

        public string FailureReason
        {
            get
            {
                return this.failureReason;
            }

            set
            {
                this.failureReason = value;
            }
        }

        public bool IsOvertaken
        {
            get
            {
                return this.isOvertaken;
            }

            set
            {
                this.isOvertaken = value;
            }
        }
    }
}
