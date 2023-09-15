using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Models
{
    public class Track
    {
        private int lapsNumber;

        private int length;

        public Track(int lapsNumber, int length)
        {
            this.LapsNumber = lapsNumber;
            this.Length = length;
        }

        public int LapsNumber
        {
            get 
            { 
                return lapsNumber; 
            }

            set
            {
                this.lapsNumber = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }

            set
            {
                this.length = value;
            }
        }
    }
}
