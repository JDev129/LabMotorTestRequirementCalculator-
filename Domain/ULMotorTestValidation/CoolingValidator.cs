using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class CoolingValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().CoolingIsValid;
        public string InputPrompt => new MotorValidationCenter().CoolingRequest();
        public string ValueName => "Cooling";
    }
}
