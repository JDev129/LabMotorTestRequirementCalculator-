using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class FrequencyValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().FrequencyIsValid;
        public string InputPrompt => new MotorValidationCenter().FrequencyRequest();
        public string ValueName => "frequency";
    }
}
