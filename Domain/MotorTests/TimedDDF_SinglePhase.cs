namespace MotorTests.Domain.MotorTests
{// ReSharper disable once InconsistentNaming
    public class TimedDDF_SinglePhase : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "Timed DDF SinglePhase ";
        public TimedDDF_SinglePhase(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
