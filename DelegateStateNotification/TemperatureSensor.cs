using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DelegateStateNotification
{
    public class TemperatureSensor
    {
        public delegate void TemperatureHandler(double temperature);
        public delegate double TemperatureChanger(double currentTemp);

        private TemperatureHandler handlers;
        private TemperatureChanger tempChanger;
        private double currentTemp;

        public TemperatureSensor(double initialTemp)
        {
            currentTemp = initialTemp;
        }

        public void AddHandler(TemperatureHandler handler)
        {
            if (handlers == null)
            {
                handlers = handler;
            }
            else
            {
                handlers += handler;
            }
        }

        public void RemoveHandler(TemperatureHandler handler)
        {
            var newHandlers = Delegate.Remove(handlers, handler);

            handlers = newHandlers as TemperatureHandler ?? handlers;
        }

        public void SetTempChanger(TemperatureChanger changer)
        {
            tempChanger = changer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void StartSensoring()
        {
            while (true)
            {
                currentTemp = tempChanger(currentTemp);
                handlers(currentTemp);
                Thread.Sleep(1000);
            }
        }
    }
}
