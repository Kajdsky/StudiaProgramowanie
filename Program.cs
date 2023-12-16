using CarBuilder;
using System;
using System.Threading;

namespace CarBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            FuelTank fuelTank = new FuelTank();
            Engine engine = new Engine(fuelTank);
            FuelTankDisplay fuelTankDisplay = new FuelTankDisplay(fuelTank);
            Car car = new Car(engine, fuelTank, fuelTankDisplay, 10); 

            car.EngineStart();
            while (car.CurrentSpeed < 250)
            {
                car.AccelerateTo(250);
                Console.WriteLine($"Prędkość: {car.CurrentSpeed} km/h Ilość Paliwa: {car.FuelTankDisplay.FillLevel} litrów");
                Thread.Sleep(1000);
            }
            while (car.CurrentSpeed > 0)
            {
                car.RunningIdle();
                Console.WriteLine($"Jazda Bez biegów (na luzie): {car.CurrentSpeed} km/h");
                Thread.Sleep(1000);
            }
            car.EngineStop();
            Console.WriteLine("Samochód Się Zatrzymał (Stoi).");
        }
    }
}
