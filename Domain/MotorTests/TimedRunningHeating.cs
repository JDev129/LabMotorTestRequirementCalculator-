namespace MotorTests.Domain.MotorTests
{
    public class TimedRunningHeating : LabMotorTest
    {
        public override bool HighSpeed { get; }
        public override bool LowSpeed { get; }
        public override string TestName => "Timed Running Heating ";
        public TimedRunningHeating(bool highSpeed, bool lowSpeed)
        {
            this.HighSpeed = highSpeed;
            this.LowSpeed = lowSpeed;
        }
    }
}
