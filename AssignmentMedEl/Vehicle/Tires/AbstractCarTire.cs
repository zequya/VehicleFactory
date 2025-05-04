using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Tires
{
    /// <summary>
    /// Base class for car tires.
    /// Stores shared properties like tire pressure.
    /// </summary>
    /// <param name="pressure">The initial pressure of the tire.</param>
    public abstract class AbstractCarTire(float pressure)
    {
        public float Pressure { get; set; } = pressure;
    }
}
