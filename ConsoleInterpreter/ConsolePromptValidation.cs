using System;
using Commons;
namespace ConsoleInterpreter
{
    public class ConsolePromptValidation
    {
        private IConsoleInputValidator ConsoleValidator { get; }
        private Func<string, string> defaultErrorMessage => 
            (attemptedVal) =>
                " * ' " + attemptedVal + " '  is not a valid " + this.ConsoleValidator.ValueName + ". * ".NewLine() +
                " *  Please select from the options or formats below.  *    ".NewLine();

        public ConsolePromptValidation(IConsoleInputValidator consoleValidator)
        {
            this.ConsoleValidator = consoleValidator;
        }

        public string RunValidation() => 
            RetrieveValidatedConsoleValue(out _);

        public string RunValidation(Func<string, string> failureMessage) =>
            RetrieveValidatedConsoleValue(out _, failureMessage);

        public string RunValidation(out string result) => 
            RetrieveValidatedConsoleValue(out result);

        public string RunValidation(out string result, Func<string, string> failureMessage) =>
            RetrieveValidatedConsoleValue(out result, failureMessage);


        private string RetrieveValidatedConsoleValue(out string res) =>
            RetrieveValidatedConsoleValue(out res, defaultErrorMessage);

        private string RetrieveValidatedConsoleValue(out string res, Func<string, string> failureMessage)
        {
            var result = ActThenRead(() => Console.Write(this.ConsoleValidator.InputPrompt));
            while (!this.ConsoleValidator.Validate(result))
            {
                var result1 = result;
                result = ActThenRead(() => Console.Write(failureMessage(result1).NewLine() + 
                                            this.ConsoleValidator.InputPrompt));
            }
            res = result;
            return result;
        }

        private static string ActThenRead(Action act)
        {
            act();
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
