using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class PhaseValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().PhaseIsValid;
        public string InputPrompt => new MotorValidationCenter().PhaseRequest();
        public string ValueName => "Phase";
    }
}
