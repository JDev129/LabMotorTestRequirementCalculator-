using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class SpeedValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().SpeedIsValid;
        public string InputPrompt => new MotorValidationCenter().SpeedRequest();
        public string ValueName => "Speed";
    }
}
