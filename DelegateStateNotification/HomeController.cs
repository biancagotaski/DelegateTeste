using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DelegateStateNotification
{
    public class HomeController
    {

        public const double MaxTemperature = 30.0;
        public const double MinTemperature = 17.0;

        private readonly TemperatureSensor tempSensor;
        private readonly AirConditioner airConditioner;
        public double CurrentTemperature { get; set; }
        public string Name { get; set; }


        public HomeController(string homeName, TemperatureSensor tempSensor): this(homeName, tempSensor, new AirConditioner())
        {
        }
        public HomeController(string homeName, TemperatureSensor tempSensor, AirConditioner airConditioner)
        {
            this.tempSensor = tempSensor;
            this.airConditioner = airConditioner;
            Name = homeName;
            tempSensor.AddHandler(TemperatureChanged);
            CoolHome();
            new Thread(StartTempSensor).Start();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void TemperatureChanged(double newTemp)
        {
            CurrentTemperature = newTemp;

            Console.WriteLine("({0}) Nova Temperatura: {1:F2} C", Name, newTemp);

            if (CurrentTemperature > MaxTemperature && airConditioner.State == AirConditioner.AirConditionerState.Heating)
            {
                CoolHome();
            }
            else if (CurrentTemperature < MinTemperature && airConditioner.State == AirConditioner.AirConditionerState.Freezing)
            {
                WarmHome();
            }
        }

        private void CoolHome()
        {
            Console.Write($"({Name}) ");
            airConditioner.TurnOnAirConditionerFreezing();
            tempSensor.SetTempChanger(airConditioner.DecreaseTemperature);
        }

        private void WarmHome()
        {
            Console.Write($"({Name}) ");
            airConditioner.TurnOnAirConditionerHeating();
            tempSensor.SetTempChanger(airConditioner.IncreaseTemperature);
        }

        private void StartTempSensor()
        {
            tempSensor.StartSensoring();
        }
    }
}
