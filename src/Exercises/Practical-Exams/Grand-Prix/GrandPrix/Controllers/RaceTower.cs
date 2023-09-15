using GrandPrix.Classes;
using GrandPrix.Classes.Tires;
using GrandPrix.Models;
using GrandPrix.Models.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Controllers
{
    public class RaceTower
    {
        private Track track;

        private List<Driver> drivers;

        public RaceTower()
        {
            this.Drivers = new List<Driver>();
        }

        public Track Track
        {
            get
            {
                return this.track;
            }

            set
            {
                this.track = value;
            }
        }

        public List<Driver> Drivers
        {
            get
            {
                return drivers;
            }

            set
            {
                this.drivers = value;
            }
        }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.Track = new Track(lapsNumber, trackLength);
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];
            int carHP = int.Parse(commandArgs[2]);
            float fuelAmount = float.Parse(commandArgs[3]);
            string tyreType = commandArgs[4];
            float tyreHardness = float.Parse(commandArgs[5]);

            Tyre carTyre = null;

            switch (tyreType)
            {
                case "Ultrasoft":
                    float ultraSoftTyreGrip = float.Parse(commandArgs[6]);
                    carTyre = new UltrasoftTyre(tyreHardness, ultraSoftTyreGrip);
                    break;
                case "Hard":
                    carTyre = new HardTyre(tyreHardness);
                    break;
            }

            Car car = new Car(carHP, fuelAmount, carTyre);

            Driver driver = null;

            switch (driverType)
            {
                case "Aggressive":
                    driver = new AggressiveDriver(driverName, car);
                    break;
                case "Endurance":
                    driver = new EnduranceDriver(driverName, car);
                    break;
            }

            drivers.Add(driver);
        }

        public void DriverBoxes(List<string> commandArgs)
        {

        }

        public void CompleteLaps(List<string> commandArgs) 
        {
            int numberOfLaps = int.Parse(commandArgs[0]);

            for (int i = 0; i < numberOfLaps; i++)
            {
                foreach (var driver in drivers)
                {
                    driver.TotalTime += 60 / track.Length / driver.Speed;
                    driver.Car.FuelAmount -= track.Length * driver.FuelConsumptionPerKm;
                    
                    // degrade according to car tyre type
                }
            }
        }

        public string GetLeaderboard() 
        { 
            return null; 
        }

        public void ChangeWeather(List<string> commandArgs)
        {

        }
    }
}
