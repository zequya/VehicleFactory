using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Tires
{
    public class AbstractCarTire(float pressure)
    {
        public float Pressure { get; set; } = pressure;
    }
}
