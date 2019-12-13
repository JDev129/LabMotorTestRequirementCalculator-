using System;
using Commons;

namespace ConsoleInterpreter
{
    public class YesNoValidator : IConsoleInputValidator
    {
        public Func<object, bool> Validate => new SelectableDataOptions(new object[] {"yes", "no"}).IsValidDataValue;
        public string InputPrompt => " [options: ( yes/no)] : ";
        public string ValueName => " yes or no ";
    }
}
