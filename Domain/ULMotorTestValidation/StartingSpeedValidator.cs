using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class StartingSpeedValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().StartingSpeedIsValid;
        public string InputPrompt => new MotorValidationCenter().StartingSpeedRequest();
        public string ValueName => "Starting Speed";
    }
}
