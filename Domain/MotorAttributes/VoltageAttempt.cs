using Commons;
using CertificationLabMotorTest.Domain.Entities;

namespace CertificationLabCertification.Domain.MotorAttributes
{
    public class VoltageAttempt
    {
        public VoltageType VoltageType { get; }
        public string AttemptedValue { get; }
        public string[] AttemptedSpread { get; }
        public string[] AttemptedDualSplit { get; }

        public VoltageAttempt(string attempt)
        {
            this.AttemptedValue = attempt;
            this.AttemptedSpread = attempt.NumbersSplitOnDashes();
            this.AttemptedDualSplit = attempt.NumbersSplitOnForwardSlash();
            this.VoltageType = SetVoltage();
        }

        private VoltageType SetVoltage() =>
                    (this.AttemptedValue.IsIntegerAndGreaterThanZero()) ?
                        VoltageType.Single :
                    (this.AttemptedSpread.Length == 2 
                    &&
                     this.AttemptedSpread[0].IsIntegerAndGreaterThanZero() &&
                     this.AttemptedSpread[1].IsIntegerAndGreaterThanZero()) ?
                        VoltageType.Spread :
                    (this.AttemptedDualSplit.Length == 2 
                    &&
                     (this.AttemptedDualSplit[0].IsIntegerAndGreaterThanZero()) &&
                     (this.AttemptedDualSplit[1].IsIntegerAndGreaterThanZero())) ?
                        VoltageType.Dual :
                    (this.AttemptedDualSplit.Length == 2 
                    &&
                     (this.AttemptedDualSplit[0].IsIntegerAndGreaterThanZero() ||
                      (this.AttemptedDualSplit[0].NumbersSplitOnDashes().Length == 2 &&
                       this.AttemptedDualSplit[0].NumbersSplitOnDashes()[0].IsIntegerAndGreaterThanZero() &&
                       this.AttemptedDualSplit[0].NumbersSplitOnDashes()[1].IsIntegerAndGreaterThanZero()))
                     &&
                     (this.AttemptedDualSplit[1].IsIntegerAndGreaterThanZero() ||
                      (this.AttemptedDualSplit[1].NumbersSplitOnDashes().Length == 2 &&
                      this.AttemptedDualSplit[1].NumbersSplitOnDashes()[0].IsIntegerAndGreaterThanZero() &&
                      this.AttemptedDualSplit[1].NumbersSplitOnDashes()[1].IsIntegerAndGreaterThanZero()))) ?
                        VoltageType.DualSpread :
                        VoltageType.Invalid;

        public bool IsValidVoltage() => (this.VoltageType != VoltageType.Invalid);
    }
}
