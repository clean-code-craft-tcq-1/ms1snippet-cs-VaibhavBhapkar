using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorValidate
{
    public class SensorValidator
    {
        private readonly IParameterDelta _iParameterDelta;
        public SensorValidator(IParameterDelta iParameterDelta)
        {
            this._iParameterDelta = iParameterDelta;
        }
        private bool CheckNextAndPresentValueDifferenceWithDelta(double? value, double? nextValue, double maxDelta)
        {
            if (nextValue - value > maxDelta)
            {
                return false;
            }
            return true;
        }
        public bool ValidateSOCReadings(List<Double?> values)
        {
            if (!CheckNullValueInReadings(values))
            {
                return EvaluateParameterReadings(values, _iParameterDelta.maxSOCDelta);
            }
            return false;
        }
        public bool ValidateCurrentReadings(List<Double?> values)
        {
            if (!CheckNullValueInReadings(values))
            {
                return EvaluateParameterReadings(values, _iParameterDelta.maxCurrentDelta);
            }
            return false;
        }
        private bool EvaluateParameterReadings(List<Double?> values, double maxDelta)
        {

            int lastIndex = values.Count - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                if (!CheckNextAndPresentValueDifferenceWithDelta(values[i], values[i + 1], maxDelta))
                {
                    return false;
                }
            }
            return true;

        }
        private bool CheckNullValueInReadings(List<Double?> values)
        {
            if (values.Any(value => value == null))
            {
                return true;
            }
            return false;
        }

    }
}
