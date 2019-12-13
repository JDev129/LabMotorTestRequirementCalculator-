namespace MotorTests.Domain.MotorTests
{
    public abstract class LabMotorTest : IMotorTest
    {
        public abstract bool HighSpeed { get; }
        public abstract bool LowSpeed { get; }
        public abstract string TestName { get; }
        public string RequiredTest() => 
            this.HighSpeed && this.LowSpeed ?
                " High Speed" + " " + this.TestName + "\r\n" +
                " Low Speed" + " " + this.TestName :
            this.HighSpeed ?
                " High Speed" + " " + this.TestName :
            this.LowSpeed ?
                " Low Speed" + " " + this.TestName :
                string.Empty;
    }
}
