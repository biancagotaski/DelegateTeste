using System;

namespace DelegateStateNotification
{
    public class AirConditioner
    {
        public enum AirConditionerState{ Heating, Freezing }


        private readonly Random rand = new Random();
        public AirConditionerState State { get; set; } = AirConditionerState.Heating;

        public void TurnOnAirConditionerFreezing()
        {
            if (State == AirConditionerState.Heating)
            {
                Console.WriteLine("Ar condicionado em modo de resfriamento.");
                State = AirConditionerState.Freezing;
            }
            
        }

        public void TurnOnAirConditionerHeating()
        {
            if (State == AirConditionerState.Freezing)
            {
                Console.WriteLine("Ar condicionado em modo de aquecimento.");
                State = AirConditionerState.Heating;
            }
        }

        public double IncreaseTemperature(double currentTemp)
        {
            return currentTemp + rand.NextDouble();
        }

        public double DecreaseTemperature(double currentTemp)
        {
            return currentTemp - rand.NextDouble();
        }
    }
}
