using System;

namespace ConsoleInterpreter
{
    public interface IConsoleInputValidator
    {
        Func<object, bool> Validate { get; }
        string InputPrompt { get; }
        string ValueName { get; }
    }
}