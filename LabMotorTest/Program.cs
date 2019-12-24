using CertificationStandard.Domain.CertificationMotorTestValidation;
using Commons;
using ConsoleInterpreter;
using MotorTests.Common;
using MotorTests.Domain.Entities;
using System;

namespace LabMotorTest
{
    static class ProgramHelper
    {
        public static bool isSixtyHz(this string validatedFrequency) => validatedFrequency == "60" || validatedFrequency == "60/50";
        public static bool isFiftyHz(this string validatedFrequency) => validatedFrequency == "50" || validatedFrequency == "60/50";
    }
    class Program
    {
        private static ConsolePromptValidation ConsoleReader(IConsoleInputValidator consoleValueValidator) => 
            new ConsolePromptValidation(consoleValueValidator);
        
        private static void WriteNewLine(string value)
        {
            Console.WriteLine("".NewLine() + value);
        }

        private static void Main()
        {

            var OkToContinue = true;
            WriteNewLine("  Welcome to the Lab Test Requirements Calculator ");
            while (OkToContinue)
            {
                WriteNewLine("  Please provide the required parameters of the specified electric motor. ".NewLine());
                WriteNewLine("  Calculate Test Requirements.                    :  Electric Motor Characteristics ".NewLine());
                WriteNewLine("  Please preform the following tests to meet certification requirements. ".NewLine().NewLine() + 
                                    new CertifiableMotor(
                                            ConsoleReader(new FrequencyValidator()).RunValidation(out var validatedFrequency),
                                            validatedFrequency.isSixtyHz() ? ConsoleReader(new VoltageValidator(false)).RunValidation() : string.Empty,
                                            validatedFrequency.isFiftyHz() ? ConsoleReader(new VoltageValidator(true)).RunValidation() : string.Empty,
                                            ConsoleReader(new OverloadValidator()).RunValidation(),
                                            ConsoleReader(new CoolingValidator()).RunValidation(),
                                            ConsoleReader(new DutyCycleValidator()).RunValidation(),
                                            ConsoleReader(new PhaseValidator()).RunValidation(),
                                            ConsoleReader(new SpeedValidator()).RunValidation(out var validatedSpeed),
                                            (validatedSpeed == "2")
                                                ? ConsoleReader(new StartingSpeedValidator()).RunValidation() : string.Empty)
                                        .GetRequiredTests()
                                        .BuildOutput((result) => result.NewLine()));
                WriteNewLine(" Perform another test calculation? ".NewLine());
                OkToContinue = 
                    ConsoleReader(
                        new YesNoValidator())
                        .RunValidation(
                            (failedAttempt) => "'" + failedAttempt + "' please enter either 'yes' or 'no").ToLower() == "yes";
            }
            WriteNewLine(" Thanks for visiting, goodbye. Let us know how your experience was at http://freadomfighters.wra/maybeinthefutre/thisisnotreal... ");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
