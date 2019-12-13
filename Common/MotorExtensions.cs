using MotorTests.Domain;
using MotorTests.Domain.Entities;
using MotorTests.Domain.MotorTests;
using System.Collections.Generic;

namespace MotorTests.Common
{
    public static class CertifiableMotorExtensions
    {
        public static List<string> GetRequiredTests(
            this CertifiableMotor validMotor)
        {
            var @this = new List<string>();
            foreach (var motorTest in validMotor.CalculateRequiredTests())
                @this.Add(motorTest.RequiredTest());
            return @this;
        }

        public static IEnumerable<IMotorTest> CalculateRequiredTests(
            this CertifiableMotor validMotor) => new TestsCalculation(validMotor).RequiredTests();
    }
}
