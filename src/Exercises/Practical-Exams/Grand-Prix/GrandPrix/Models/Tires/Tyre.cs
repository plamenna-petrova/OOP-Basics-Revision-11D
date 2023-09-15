using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Classes.Tires
{
    public class Tyre
    {
        private string name;

        private float hardness;

        private float degradation;

        public Tyre(float hardness)
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

        public float Hardness
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

        public float Degradation
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
