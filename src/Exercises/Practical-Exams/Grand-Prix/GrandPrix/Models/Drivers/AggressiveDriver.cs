using GrandPrix.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Models.Drivers
{
    public class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, Car car) 
            : base(name, car)
        {
            this.FuelConsumptionPerKm = 2.7;
        }
    }
}
