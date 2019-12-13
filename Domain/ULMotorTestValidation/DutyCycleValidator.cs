using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class DutyCycleValidator :  IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().DutyCycleIsValid;
        public string InputPrompt => new MotorValidationCenter().DutyCycleRequest();
        public string ValueName => "Duty Cycle";
    }
}
