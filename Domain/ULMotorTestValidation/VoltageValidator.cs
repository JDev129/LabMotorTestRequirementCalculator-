using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class VoltageValidator : IConsoleInputValidator
    {
        private bool Is50Hz { get; }
        public VoltageValidator(bool at50Hz)
        {
            this.Is50Hz = at50Hz;
        }

        public Func<object, bool> Validate =>
            new MotorValidationCenter().VoltageIsValid;

        public string InputPrompt =>
            this.Is50Hz ?
                new MotorValidationCenter().VoltageAt50Request() :
                new MotorValidationCenter().VoltageAt60Request();

        public string ValueName => "Voltage";

    }
}
