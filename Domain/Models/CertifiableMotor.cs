using CertificationLabCertification.Domain.MotorAttributes;
using CertificationLabMotorTest.Domain.Entities;
using Commons;

namespace MotorTests.Domain.Entities
{
    public static class MotorHelper
    {
        public static Option<CertifiableMotor> TryGetMotor((
            string frequency,
            string voltageAt60,
            string voltageAt50,
            string isOverload,
            string cooling,
            string dutyCycle,
            string phase,
            string speed,
            string startingSpeed) parameters)
        {
            var resultIfValid = new CertifiableMotor(
                parameters.frequency,
                parameters.voltageAt60,
                parameters.voltageAt50,
                parameters.isOverload,
                parameters.cooling,
                parameters.dutyCycle,
                parameters.phase,
                parameters.speed,
                parameters.startingSpeed);
            if (resultIfValid.isCertifiable)
                return resultIfValid;
            else
                return None.Value;
        }
    }

    public class CertifiableMotor
    {
        public bool isCertifiable { get; private set; }

        public VoltageAttempt VoltageAt50Hz { get; private set; }
        public VoltageAttempt VoltageAt60Hz { get; private set; }
        public FrequencyOption FrequencyOption { get; private set; }
        public int Value { get; private set; }
        public int SecondValue { get; private set; }
        public CoolingOption CoolingOption { get; private set; }
        public CoolingOption Cooling { get; private set; }
        public SpeedOption Speed { get; private set; }
        public PhaseOption Phase { get; private set; }
        public DutyCycleOption DutyCycle { get; private set; }
        public bool IsOverload { get; private set; }
        public StartingSpeedOption StartingSpeedOption { get; private set; }

        public CertifiableMotor(
            string frequency, 
            string voltageAt60, 
            string voltageAt50, 
            string isOverload, 
            string cooling, 
            string dutyCycle, 
            string phase,  
            string speed, 
            string startingSpeed)
        {
            SetFrequency(frequency);
            SetVoltage(voltageAt60, voltageAt50);
            SetCooling(cooling);
            SetDutyCycle(dutyCycle.ToLower().Trim());
            SetPhase(phase);
            SetOverload(isOverload);
            SetSpeed(speed);
            SetStartingSpeed(startingSpeed);
        }

        private void SetFrequency(string frequency)
        {
            if (string.IsNullOrEmpty(frequency))
                isCertifiable = false;
            if (frequency == "60/50")
            {
                this.Value = 60;
                this.SecondValue = 50;
                this.FrequencyOption = FrequencyOption.Double;
            }
            else if (frequency == "50")
            {
                this.Value = 50;
                this.FrequencyOption = FrequencyOption.Single;
            }
            else if (frequency == "60")
            {
                this.Value = 60;
                this.FrequencyOption = FrequencyOption.Single;
            }
            else
                isCertifiable = false;

        }
        private void SetVoltage(string voltageAt60, string voltageAt50)
        {
            if (this.FrequencyOption == FrequencyOption.Double)
            {
                this.VoltageAt60Hz = new VoltageAttempt(voltageAt60);
                this.VoltageAt50Hz = new VoltageAttempt(voltageAt50);
                if (!this.VoltageAt60Hz.IsValidVoltage())
                    this.isCertifiable = false;
                if (!this.VoltageAt50Hz.IsValidVoltage())
                    this.isCertifiable = false;
            }
            else
            {

                if (this.Value == 60)
                {
                    this.VoltageAt60Hz = new VoltageAttempt(voltageAt60);
                    if (!this.VoltageAt60Hz.IsValidVoltage())
                        this.isCertifiable = false;
                }
                else if (this.Value == 50)
                {
                    this.VoltageAt50Hz = new VoltageAttempt(voltageAt50);
                    if (!this.VoltageAt50Hz.IsValidVoltage())
                        this.isCertifiable = false;
                }
                else
                    this.isCertifiable = false;
            }
        }
        private void SetCooling(string cooling)
        {
            switch (cooling)
            {
                case "AO":
                    this.Cooling = CoolingOption.AO;
                    break;
                case "Self":
                    this.Cooling = CoolingOption.Self;
                    break;
                default:
                    isCertifiable = false;
                    break;
            }
        }
        private void SetSpeed(string speed)
        {
            if (speed == "1" || speed.ToLower().Trim() == "single")
                this.Speed = SpeedOption.Single;
            else if (speed == "2" || speed.ToLower().Trim() == "two" || speed.ToLower().Trim() == "double")
                this.Speed = SpeedOption.Two;
            else
                this.isCertifiable = false;
        }
        private void SetStartingSpeed(string startingSpeed)
        {
            if (this.Speed == SpeedOption.Two && (startingSpeed == "None" || string.IsNullOrEmpty(startingSpeed)))
                isCertifiable = false;
            if (this.Speed == SpeedOption.Single && (startingSpeed == "High" || startingSpeed == "Low" || startingSpeed == "Both"))
                isCertifiable = false;
            if (startingSpeed.ToLower().Trim() == "high" && this.Speed == SpeedOption.Two)
                this.StartingSpeedOption = StartingSpeedOption.High;
            else if (startingSpeed.ToLower().Trim() == "low" && this.Speed == SpeedOption.Two)
                this.StartingSpeedOption = StartingSpeedOption.Low;
            else if (startingSpeed.ToLower().Trim() == "both" && this.Speed == SpeedOption.Two)
                this.StartingSpeedOption = StartingSpeedOption.Both;
            else if (startingSpeed.ToLower().Trim() == "none" && this.Speed == SpeedOption.Single)
                this.StartingSpeedOption = StartingSpeedOption.None;
            else if (startingSpeed == "" && this.Speed == SpeedOption.Single)
                this.StartingSpeedOption = StartingSpeedOption.None;
            else
                isCertifiable = false;
        }
        private void SetDutyCycle(string thedutyCycle)
        {
            if (thedutyCycle == "int" || thedutyCycle == "int." || thedutyCycle == "intermittent")
                this.DutyCycle = DutyCycleOption.Int;
            else if (thedutyCycle == "cont" || thedutyCycle == "cont." || thedutyCycle == "continuous")
                this.DutyCycle = DutyCycleOption.Cont;
            else
                isCertifiable = false;
        }
        private void SetOverload(string isOverload)
        {
            if (!bool.TryParse(isOverload.ToLower(), out bool overloadres))
                this.isCertifiable = false;
            this.IsOverload = overloadres;
        }
        private void SetPhase(string phase)
        {
            if (phase == "1")
                this.Phase = PhaseOption.Single;
            else if (phase == "3")
                this.Phase = PhaseOption.Three;
            else
                isCertifiable = false;
        }
    }
}
