using System;
using System.Collections.Generic;
using System.Text;
using GrandPrix.Classes;

namespace GrandPrix.Models.Drivers
{
    public class Driver
    {
        private string name;

        private double totalTime;

        private Car car;

        private double fuelConsumptionPerKm;

        private double speed;

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

        public double TotalTime
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

        public double FuelConsumptionPerKm
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

        public double Speed
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
