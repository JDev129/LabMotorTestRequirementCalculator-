namespace MotorTests.Domain.MotorTests
{
    public class TimedHeatRun : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "Timed Heat Run ";
        public TimedHeatRun(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
