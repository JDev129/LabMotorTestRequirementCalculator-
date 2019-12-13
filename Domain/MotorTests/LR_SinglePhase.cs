namespace MotorTests.Domain.MotorTests
{// ReSharper disable once InconsistentNaming
    public class LR_SinglePhase : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "LR SinglePhase ";
        public LR_SinglePhase(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
