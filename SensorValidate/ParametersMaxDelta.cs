using System;
using System.Collections.Generic;
using System.Text;

namespace SensorValidate
{
    public class ParametersMaxDelta : IParameterDelta
    {
        public double maxSOCDelta => 0.05;

        public double maxCurrentDelta => 0.1;
    }
}
