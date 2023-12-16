using System;

namespace CarBuilder
{
    public class FuelTank : IFuelTank
    {
        public double FillLevel { get; private set; }
        public bool IsOnReserve { get; private set; }
        public FuelTank()
        {
            FillLevel = 20; 
            IsOnReserve = false;
        }

        public void Refuel(double liters)
        {
            FillLevel += liters;
            if (FillLevel > 60)
            {
                FillLevel = 60;
                Console.WriteLine("Bak jest pełen");
            }
            if (FillLevel > 5)
            {
                IsOnReserve = false;
            }
        }

        public void Consume(double liters)
        {
            FillLevel -= liters;
            if (FillLevel < 5)
            {
                IsOnReserve = true;
                if (FillLevel < 0)
                {
                    FillLevel = 0;
                    Console.WriteLine("Bak jest pusty");
                }
            }
        }

        public double CalculateFuelConsumption(int speed)
        {
            if (speed >= 1 && speed <= 60)
            {
                return 0.0020;
            }
            else if (speed >= 61 && speed <= 100)
            {
                return 0.0014;
            }
            else if (speed >= 101 && speed <= 140)
            {
                return 0.0020;
            }
            else if (speed >= 141 && speed <= 200)
            {
                return 0.0025;
            }
            else if (speed >= 201 && speed <= 250)
            {
                return 0.0030;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
