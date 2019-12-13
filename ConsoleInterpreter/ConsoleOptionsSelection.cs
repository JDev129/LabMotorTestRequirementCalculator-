using System;
using System.Collections.Generic;
using Commons;
namespace ConsoleInterpreter
{
    public class ConsoleOptionsSelection
    {
        public List<(string name, string id)> Options { get; }
        public string OptionsName { get; }

        private bool intId { get; }

        private string NameSingular =>
            (this.OptionsName.Trim().EndsWith("s") ? this.OptionsName.Trim().Substring(0, this.OptionsName.Trim().Length - 1) : this.OptionsName);

        public ConsoleOptionsSelection(string optionsName, List<(string name, string id)> options)
        {
            this.Options = options;
            this.OptionsName = optionsName;
            this.intId = false;
        }

        private string WriteOutOptions() =>
            Options.ForEachAdd(
                (item) => " " + item.name.AddNumberOfSpaces(35 - item.name.Length) + "   id : " + item.id.NewLine());

        public (string name, string id) ReRunValidation() =>
            Extend.ActThenReturn(
                () => Console.Write(
                            "".NewLine() + " please enter id of selection : "),
                () => RunValidation(Console.ReadLine() ?? string.Empty));

        public (string name, string id) RunValidation(out bool ran)
        {
            ran = true;
            return this.RunValidation();
        }

        public void DisplayOptions() =>
            Console.Write("".NewLine() + WriteOutOptions().NewLine());

        public (string name, string id) RunValidation() =>
            Extend.ActThenReturn(
                () => Console.Write(
                            "".NewLine() + " please select one of the following " + this.OptionsName + ".".NewLine().NewLine() +
                            WriteOutOptions().NewLine() +
                             " please enter id of selection : "),
                () => RunValidation(Console.ReadLine() ?? string.Empty));

        private (string name, string id) RunValidation(string input) =>
            (InputIsValid(input, out (string name, string id) KeyValResult)) ?
                KeyValResult :
                OnInvalidAttemptString(input);

        private (string name, string id) OnInvalidAttemptString(string attempt) =>
            Extend.ActThenReturn(
                () => Console.Write("  " + attempt + " is not a valid " + this.NameSingular.NewLine() +
                                    " please enter one of the listed " + this.NameSingular + " id's : "),
                () => RunValidation(Console.ReadLine() ?? string.Empty));

        private bool InputIsValid(string attempt, out (string name, string id) validResult)
        {
            var res = this.isValid(attempt);
            validResult = res.Item2;
            return res.Item1;
        }

        private (bool, (string name, string id)) isValid(string input) =>
            Options.CheckEachForAMatch((item) => (item.id.Trim().ToLower() == input.Trim().ToLower()));
    }
}
