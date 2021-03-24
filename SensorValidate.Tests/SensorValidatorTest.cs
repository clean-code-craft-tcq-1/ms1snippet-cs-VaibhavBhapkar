using System;
using System.Collections.Generic;

using Xunit;

namespace SensorValidate.Tests
{
    public class SensorValidatorTest
    {
        SensorValidator sensorValidator;
        public SensorValidatorTest()
        {
            IParameterDelta iParameterDelta = new ParametersMaxDelta();
             sensorValidator = new SensorValidator(iParameterDelta);
        }

        [Fact]
        public void ReportsErrorWhenSOCJumps() {
            Assert.False(sensorValidator.ValidateSOCReadings(
                new List<double?>{0.0, 0.01, 0.5, 0.51}
            ));            
        }
        [Fact]
        public void ReportsErrorWhenCurrentJumps() {
            Assert.False(sensorValidator.ValidateCurrentReadings(
                new List<double?>{0.03, 0.03, 0.03, 0.33}
            ));
        }
        [Fact]
        public void ReportsErrorWhenCurrentWithNull()
        {
            Assert.False(sensorValidator.ValidateCurrentReadings(
                new List<double?> { 0.03, 0.03, null, 0.33 }
            ));
        }
        [Fact]
        public void ReportsOkWhenSOCIsFine()
        {
            Assert.True(sensorValidator.ValidateSOCReadings(
                new List<double?> { 0.0, 0.01, 0.05, 0.09 }
            ));
        }
    }
}
