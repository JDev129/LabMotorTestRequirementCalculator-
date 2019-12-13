using System;
using CertificationStandard.Domain.Helpers;
using ConsoleInterpreter;

namespace CertificationStandard.Domain.CertificationMotorTestValidation
{
    public class OverloadValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new MotorValidationCenter().OverloadIsValid;
        public string InputPrompt => new MotorValidationCenter().OverloadRequest();
        public string ValueName => "Overload";
    }
}
