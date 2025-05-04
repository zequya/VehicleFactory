using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Tires
{
    /// <summary>
    /// Winter tire for a vehicle.
    /// Inherits from <see cref="AbstractCarTire"/> and adds minimum temperature and thickness.
    /// </summary>
    /// <param name="pressure">Initial tire pressure.</param>
    /// <param name="minTemperature">Minimum temperature of the tire.</param>
    /// <param name="thickness">Thickness of the tire.</param>
    public class WinterTire(float pressure, float minTemperature, float thickness) : AbstractCarTire(pressure)
    {
        private readonly float _minTemperature = minTemperature;
        private readonly float _thickness = thickness;

        public override string ToString()
        {
            return $" And Winter-tires with:{Environment.NewLine} Pressure: {Pressure}{Environment.NewLine} MinTemperature: {_minTemperature}{Environment.NewLine} Thickness: {_thickness}";
        }
    }
}
