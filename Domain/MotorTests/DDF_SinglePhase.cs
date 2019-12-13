namespace MotorTests.Domain.MotorTests
{// ReSharper disable once InconsistentNaming
    public class DDF_SinglePhase : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "DDF SinglePhase ";
        public DDF_SinglePhase(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
