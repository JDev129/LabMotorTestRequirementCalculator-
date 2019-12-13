namespace MotorTests.Domain.MotorTests
{// ReSharper disable once InconsistentNaming
    public class TimedDDF_ThreePhase : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "Timed DDF ThreePhase ";
        public TimedDDF_ThreePhase(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
