using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    
    public class SummerTire(float pressure, float maxTemperature) : AbstractCarTire(pressure)
    {
        private readonly float _maxTemperature = maxTemperature;

        public override string ToString()
        {
            return $" And Summer-tires with:\n Pressure: {Pressure}\n MaxTemperature: {_maxTemperature}";
        }
    }
}
