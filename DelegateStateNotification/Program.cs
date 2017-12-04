using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateStateNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            
            var casa1Controller = new HomeController("Casa 1", new TemperatureSensor(rand.Next(16, 31)), new AirConditioner());
            var casa2Controller = new HomeController("Casa 2", new TemperatureSensor(rand.Next(16, 31)), new AirConditioner());
        }
    }
}
