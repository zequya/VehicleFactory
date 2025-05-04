using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Tires
{
    /// <summary>
    /// Summer tire for a vehicle.
    /// Inherits from <see cref="AbstractCarTire"/> and adds maximum temperature.
    /// </summary>
    /// <param name="pressure">Initial tire pressure.</param>
    /// <param name="maxTemperature">Maximum temperature of the tire.</param>
    public class SummerTire(float pressure, float maxTemperature) : AbstractCarTire(pressure)
    {
        private readonly float _maxTemperature = maxTemperature;

        public override string ToString()
        {
            return $" And Summer-tires with:{Environment.NewLine} Pressure: {Pressure}{Environment.NewLine} MaxTemperature: {_maxTemperature}";
        }
    }
}
