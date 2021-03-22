using System;
using System.Collections.Generic;

namespace SensorValidate
{
    public class SensorValidator
    {
        public static bool _give_me_a_good_name(double value, double nextValue, double maxDelta) {
            if(nextValue - value > maxDelta) {
                return false;
            }
            return true;
        }
        public static bool validateSOCreadings(List<Double> values) {
            int lastButOneIndex = values.Count - 1;
            for(int i = 0; i < lastButOneIndex; i++) {
                if(!_give_me_a_good_name(values[i], values[i + 1], 0.05)) {
                    return false;
                }
            }
            return true;
        }
        public static bool validateCurrentreadings(List<Double> values) {
            int lastButOneIndex = values.Count - 1;
            for(int i = 0; i < lastButOneIndex; i++) {
                if(!_give_me_a_good_name(values[i], values[i + 1], 0.1)) {
                    return false;
                }
            }
            return true;
        }
    }
}
