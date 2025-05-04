using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class WinterTire(float pressure, float minTemperature, float thickness) : AbstractCarTire(pressure)
    {
        private readonly float _minTemperature = minTemperature;
        private readonly float _thickness = thickness;

        public override string ToString()
        {
            return $" And Winter-tires with:\n Pressure: {Pressure}\n MinTemperature: {_minTemperature}\n Thickness: {_thickness}";
        }
    }
}
