using GrandPrix.Classes;
using GrandPrix.Classes.Tires;
using GrandPrix.Enums;
using GrandPrix.Models;
using GrandPrix.Models.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandPrix.Controllers
{
    public class RaceTower
    {
        private Track track;

        private List<Driver> drivers;

        private bool isRaceActive;

        private int completedLaps;

        private Weather weather;

        public RaceTower()
        {
            this.Drivers = new List<Driver>();
            this.Weather = Weather.Sunny;
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

        public bool IsRaceActive
        {
            get
            {
                return this.isRaceActive;
            }

            set
            {
                this.isRaceActive = value;
            }
        }

        public int CompletedLaps
        {
            get
            {
                return this.completedLaps;
            }

            set
            {
                this.completedLaps = value;
            }
        }

        public Weather Weather
        {
            get
            {
                return this.weather;
            }

            set
            {
                this.weather = value;
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
            string reasonToBox = commandArgs[0];
            string driversName = commandArgs[1];

            Driver boxedDriver = drivers
                .Where(d => d.Name == driversName)
                .FirstOrDefault();

            boxedDriver.TotalTime += 20;

            switch (reasonToBox)
            {
                case "ChangeTyres":
                    string tyreType = commandArgs[2];
                    float tyreHardness = float.Parse(commandArgs[3]);

                    switch (tyreType)
                    {
                        case "Hard":
                            boxedDriver.Car.Tyre = new HardTyre(tyreHardness);
                            break;
                        case "Ultrasoft":
                            float tyreGrip = float.Parse(commandArgs[4]);
                            boxedDriver.Car.Tyre = new UltrasoftTyre(tyreHardness, tyreGrip);
                            break;
                    }
                    break;
                case "Refuel":
                    float fuelAmount = float.Parse(commandArgs[2]);
                    boxedDriver.Car.FuelAmount += fuelAmount;
                    break;
            }
        }

        public string CompleteLaps(List<string> commandArgs) 
        {
            int numberOfLaps = int.Parse(commandArgs[0]);

            bool isNumberOfLapsInvalid = false;

            string completedLapsMessage = null;

            if (numberOfLaps > Track.LapsNumber - CompletedLaps)
            {
                isNumberOfLapsInvalid = true;
                completedLapsMessage = $"There is no time! On lap {CompletedLaps}";
            }

            if (!isNumberOfLapsInvalid)
            {
                List<Driver> racingDrivers = drivers
                    .Where(d => d.FailureReason == null)
                    .ToList();

                for (int i = 0; i < numberOfLaps; i++)
                {
                    for (int j = 0; j < racingDrivers.Count; j++)
                    {
                        Driver currentDriver = racingDrivers[j];

                        currentDriver.Speed = (currentDriver.Car.HP + currentDriver.Car.Tyre.Degradation) / currentDriver.Car.FuelAmount;

                        if (currentDriver is AggressiveDriver)
                        {
                            currentDriver.Speed *= 3;
                        }

                        currentDriver.TotalTime += 60 / track.Length / currentDriver.Speed;
                        currentDriver.Car.FuelAmount -= track.Length * currentDriver.FuelConsumptionPerKm;

                        if (currentDriver.Car.FuelAmount <= 0)
                        {
                            currentDriver.FailureReason = "Out of fuel";
                        }

                        if (currentDriver.Car.Tyre is UltrasoftTyre)
                        {
                            UltrasoftTyre ultrasoftTyre = currentDriver.Car.Tyre as UltrasoftTyre;
                            currentDriver.Car.Tyre.Degradation -= ultrasoftTyre.Hardness + ultrasoftTyre.Grip;

                            if (currentDriver.Car.Tyre.Degradation < 30)
                            {
                                currentDriver.FailureReason = "Blown Tyre";
                            }
                        }
                        else
                        {
                            HardTyre hardTyre = currentDriver.Car.Tyre as HardTyre;
                            currentDriver.Car.Tyre.Degradation -= hardTyre.Hardness;

                            if (currentDriver.Car.Tyre.Degradation < 0)
                            {
                                currentDriver.FailureReason = "Blown Tyre";
                            }
                        }

                        if (CompletedLaps > 0 && j != racingDrivers.Count - 1)
                        {
                            int overtakeInterval = 2;

                            if (currentDriver is AggressiveDriver && currentDriver.Car.Tyre is UltrasoftTyre)
                            {
                                if (Weather == Weather.Foggy)
                                {
                                    currentDriver.FailureReason = "Crashed";
                                }
                                else
                                {
                                    overtakeInterval = 3;
                                }
                            }

                            if (currentDriver is EnduranceDriver && currentDriver.Car.Tyre is HardTyre)
                            {
                                if (Weather == Weather.Rainy)
                                {
                                    currentDriver.FailureReason = "Crashed";
                                }
                                else
                                {
                                    overtakeInterval = 3;
                                }
                            }

                            bool hasCrashed = currentDriver.FailureReason != null;

                            if (!hasCrashed)
                            {
                                List<Driver> racingDriversByTotalTime = racingDrivers
                                    .OrderBy(d => d.TotalTime)
                                    .ToList();

                                int currentDriverIndex = racingDriversByTotalTime.FindIndex(rdtl => rdtl.Name == currentDriver.Name);

                                if (currentDriverIndex != 0)
                                {
                                    Driver frontDriver = racingDriversByTotalTime[currentDriverIndex - 1];

                                    if (currentDriver.TotalTime - frontDriver.TotalTime <= overtakeInterval)
                                    {
                                        frontDriver.IsOvertaken = true;
                                        currentDriver.TotalTime -= overtakeInterval;
                                        currentDriver.TotalTime += overtakeInterval;
                                        completedLapsMessage = $"{currentDriver.Name} has overtaken {frontDriver.Name} on lap {CompletedLaps}";
                                    }
                                }
                            }
                        }
                    }

                    racingDrivers.ForEach((racingDriver) => racingDriver.IsOvertaken = false);

                    CompletedLaps++;
                }
            }

            return completedLapsMessage;
        }

        public string GetLeaderboard() 
        {
            StringBuilder leaderBoardStringBuilder = new StringBuilder();
            leaderBoardStringBuilder.AppendLine($"Lap {CompletedLaps}/{Track.LapsNumber}");

            List<Driver> driversOrderedByTotalTime = drivers
                .OrderBy(d => d.TotalTime)
                .ToList();

            for (int i = 0; i < driversOrderedByTotalTime.Count; i++)
            {
                leaderBoardStringBuilder.AppendLine($"{i + 1} {driversOrderedByTotalTime[i].Name} {driversOrderedByTotalTime[i].TotalTime}");
                
                if (driversOrderedByTotalTime[i].FailureReason != null)
                {
                    leaderBoardStringBuilder.Append($" {driversOrderedByTotalTime[i].FailureReason}");
                }
            }

            return leaderBoardStringBuilder.ToString(); 
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            string weather = commandArgs[0];

            switch (weather)
            {
                case "Rainy":
                    Weather = Weather.Rainy;
                    break;
                case "Foggy":
                    Weather = Weather.Foggy;
                    break;
                case "Sunny":
                    Weather = Weather.Sunny;
                    break;
            }
        }
    }
}
