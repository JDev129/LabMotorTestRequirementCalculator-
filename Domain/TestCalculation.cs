using Commons;
using MotorTests.Domain.Entities;
using MotorTests.Domain.MotorTests;
using System;
using System.Collections.Generic;

namespace MotorTests.Domain
{// This class solves the test requirements for a certified electric motor 
 // based on the 8 required attributes (Speed, TheVoltage, Frequency, 
 // Phase, Overload, Cooling, DutyCycle, StartingSpeed) *defined in 
 // the Lab_Testing_Rules.xlsx spreadsheet found inside 'ProjectRequirements' 
 // of the 'Documentation' directory.
 // The results are as many as 11 possible test (or 22 for dual speed) to be conducted 
 // on the motor with the charateristics that you input. The RequiredTests function
 // is the heart of the solution of this algorith.
    public class TestsCalculation
    {
        public CertifiableMotor ValidatedMotor { get; }
        private bool TwoSpeed => this.ValidatedMotor.Speed == SpeedOption.Two;
        private bool SpeedHighOrBoth => this.ValidatedMotor.StartingSpeedOption == StartingSpeedOption.High ||
                                   this.ValidatedMotor.StartingSpeedOption == StartingSpeedOption.Both;
        private bool SpeedLowOrBoth => this.ValidatedMotor.StartingSpeedOption == StartingSpeedOption.Low ||
                                  this.ValidatedMotor.StartingSpeedOption == StartingSpeedOption.Both;
        private bool CoolingAO => this.ValidatedMotor.Cooling == CoolingOption.AO;
        private bool DutyCycleCont => this.ValidatedMotor.DutyCycle == DutyCycleOption.Cont;
        private bool ThreePhase => this.ValidatedMotor.Phase == PhaseOption.Three;
        private bool Overload => this.ValidatedMotor.IsOverload;

        public TestsCalculation(CertifiableMotor validMotor)
        {
            this.ValidatedMotor = validMotor;
        }

        public IEnumerable<IMotorTest> RequiredTests() =>
            new List<IMotorTest>()
                .AddTo(new Performance(true, TwoSpeed))
                .AddToWhen(new List<(Func<bool>, IEnumerable<IMotorTest>)>(){
                    (() => Overload && !TwoSpeed && ThreePhase,
                            new List<IMotorTest>().AddTo(new LR_SinglePhase(true, false))
                                                  .AddTo(new LR_ThreePhase(true, false))),
                    (() => Overload && !TwoSpeed && !ThreePhase,
                            new LR_SinglePhase(true, false).ListOfOne()),
                    (() => Overload && !TwoSpeed && !ThreePhase,
                            new LR_SinglePhase(true, false).ListOfOne()),
                    (() => Overload && !ThreePhase && TwoSpeed,
                            new LR_SinglePhase(SpeedHighOrBoth, SpeedLowOrBoth).ListOfOne()),
                    (() => (Overload && ThreePhase && TwoSpeed),
                            new List<IMotorTest>().AddTo(new LR_ThreePhase(SpeedHighOrBoth, SpeedLowOrBoth))
                                                  .AddTo(new LR_SinglePhase(SpeedHighOrBoth, SpeedLowOrBoth))),
                    (() => Overload && ThreePhase && CoolingAO && DutyCycleCont,
                            new DDF_ThreePhase(true, TwoSpeed).ListOfOne()),
                    (() => Overload && ThreePhase && CoolingAO && !DutyCycleCont,
                            new TimedDDF_ThreePhase(true, TwoSpeed).ListOfOne()),
                    (() => Overload && !CoolingAO && DutyCycleCont,
                            new RunningHeating(true, TwoSpeed).ListOfOne()),
                    (() => Overload && !CoolingAO && !DutyCycleCont,
                            new TimedRunningHeating(true, TwoSpeed).ListOfOne()),
                    (() => Overload && CoolingAO && DutyCycleCont,
                            new DDF_SinglePhase(true, TwoSpeed).ListOfOne()),
                    (() => Overload && CoolingAO && !DutyCycleCont,
                            new TimedDDF_SinglePhase(true, TwoSpeed).ListOfOne()),
                    (() => !Overload && !CoolingAO && DutyCycleCont,
                            new HeatRun(true, TwoSpeed).ListOfOne()),
                    (() => !Overload && !CoolingAO && !DutyCycleCont,
                            new TimedHeatRun(true, TwoSpeed).ListOfOne())
                });
    }
}
