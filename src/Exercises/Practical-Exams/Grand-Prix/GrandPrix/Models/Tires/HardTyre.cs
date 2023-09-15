using System;
using System.Collections.Generic;
using System.Text;

namespace GrandPrix.Classes.Tires
{
    public class HardTyre : Tyre
    {
        public HardTyre(float hardness)
            : base(hardness)
        {
            this.Name = "Hard";
        }
    }
}
