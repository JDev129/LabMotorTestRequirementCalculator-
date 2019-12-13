using CertificationLabCertification.Domain.MotorAttributes;
using Commons;

namespace CertificationStandard.Domain.Helpers
{
    public class MotorValidationCenter
    {
        public string FrequencyRequest() =>
            " [options: 60, 50, 60/50]               Frequency : ";

        public string VoltageAt60Request() =>
            " [examples include: 55, 11-15, 11-155/199] \r\n " +
            "                              Voltage (at 60 hz) : ";

        public string VoltageAt50Request() =>
            " [examples include: 55, 11-15, 11-155/199] \r\n " +
            "                              Voltage (at 50 hz) : ";

        public string OverloadRequest() =>
            " [options: true, false]                  Overload : ";

        public string CoolingRequest() =>
            " [options: AO, Self]                      Cooling : ";

        public string DutyCycleRequest() =>
            " [options: Int, Cont]                  Duty Cycle : ";

        public string PhaseRequest() =>
            " [options: 1, 3]                            Phase : ";

        public string SpeedRequest() =>
            " [options: 1, 2]                            Speed : ";

        public string StartingSpeedRequest() =>
            " [options: High, Low, Both ]       Starting Speed : ";

        public bool VoltageIsValid(object attempt) =>
            new VoltageAttempt((string)attempt).IsValidVoltage();

        public bool FrequencyIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"60", "50", "60/50"}).IsValidDataValue(attempt);

        public bool OverloadIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"true", "false"}).IsValidDataValue(attempt);

        public bool CoolingIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"AO", "Self"}).IsValidDataValue(attempt);

        public bool DutyCycleIsValid(object attempt) =>
            new SelectableDataOptions(new object[] { "Int", "int", "intermittent", "Int.", "Intermittent", "INTERMITTENT",
                                                     "Cont", "Continuous", "continuous", "CONTINUOUS", "Cont.", "cont."})
                                                    .IsValidDataValue(attempt);

        public bool PhaseIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"1", "3"}).IsValidDataValue(attempt);

        public bool SpeedIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"1", "2"}).IsValidDataValue(attempt);

        public bool StartingSpeedIsValid(object attempt) =>
            new SelectableDataOptions(new object[] {"High", "Low", "Both"}).IsValidDataValue(attempt);
    }
}