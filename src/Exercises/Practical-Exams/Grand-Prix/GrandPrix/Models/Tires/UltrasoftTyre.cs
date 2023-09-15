using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Classes.Tires
{
    public class UltrasoftTyre : Tyre
    {
        private float grip;

        public UltrasoftTyre(float hardness, float grip)
            : base(hardness)
        {
            this.Name = "Ultrasoft";
            this.Grip = grip;
        }

        public float Grip
        {
            get
            {
                return this.grip;
            }

            set
            {
                this.grip = value;
            }
        }
    }
}
