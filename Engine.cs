using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public class Engine : IEngine
    {
        public bool IsRunning => isRunning;
        private bool isRunning = false;

        public readonly IFuelTank _fuelTank;
        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }
        public void Consume(double liters)
        {
            _fuelTank.Consume(liters);
        }
        public void Start()
        {
            isRunning = true;
        }
        public void Stop()
        {
            isRunning = false;
        }
    }
}
