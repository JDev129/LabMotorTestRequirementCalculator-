namespace MotorTests.Domain.MotorTests
{// ReSharper disable once InconsistentNaming
    public class LR_ThreePhase : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "LR ThreePhase ";
        public LR_ThreePhase(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
