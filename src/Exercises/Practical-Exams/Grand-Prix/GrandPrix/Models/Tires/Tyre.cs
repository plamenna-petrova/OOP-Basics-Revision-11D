﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Classes.Tires
{
    public class Tyre
    {
        private string name;

        private double hardness;

        private double degradation;

        public Tyre(double hardness)
        {
            this.Hardness = hardness;
            this.Degradation = 100;
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

        public double Hardness
        {
            get
            {
                return this.hardness;
            }

            set
            {
                this.hardness = value;
            }
        }

        public virtual double Degradation
        {
            get
            {
                return this.degradation;
            }

            set
            {
                this.degradation = value;
            }
        }
    }
}
