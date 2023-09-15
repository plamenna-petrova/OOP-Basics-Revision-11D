﻿using GrandPrix.Classes.Tires;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Classes
{
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
}