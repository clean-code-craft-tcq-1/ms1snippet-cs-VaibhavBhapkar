using System;
using System.Collections.Generic;
using System.Text;

namespace SensorValidate
{
    public interface IParameterDelta
    {
        double maxSOCDelta { get; }
        double maxCurrentDelta { get; }
    }
}
