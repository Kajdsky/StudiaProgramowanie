using System;

namespace CarBuilder
{
    public class Car : ICar
    {
        public int Id { get; set; }
        public bool EngineIsRunning => _engine.IsRunning;
        private readonly IEngine _engine;
        private readonly IFuelTank _fuelTank;
        private readonly IFuelTankDisplay _fuelTankDisplay;
        private int _speed;
        private int _acceleration;
        private const int MAX_SPEED = 250;
        private const int MAX_DECELERATION = 10;
        public Car(IEngine engine, IFuelTank fuelTank, IFuelTankDisplay fuelTankDisplay, int acceleration = 10)
        {
            _engine = engine;
            _fuelTank = fuelTank;
            _fuelTankDisplay = fuelTankDisplay;
            _acceleration = Math.Clamp(acceleration, 5, 20);
            _speed = 0;
        }
        public int CurrentSpeed 
        { 
            get { return _speed; } 
        }
        public IFuelTankDisplay FuelTankDisplay => _fuelTankDisplay;

        public void EngineStart()
        {
            _engine.Start();
        }
        public void EngineStop()
        {
            _engine.Stop();
        }
        public void Refuel(double liters)
        {
            _fuelTank.Refuel(liters);
        }
        public void RunningIdle()
        {
            if (_engine.IsRunning)
            {
                Move();
            }
        }
        public void AccelerateTo(int targetSpeed)
        {
            if (!_engine.IsRunning || _speed >= targetSpeed) return;

            _speed = Math.Min(_speed + _acceleration, targetSpeed);
            _speed = Math.Min(_speed, MAX_SPEED);

            ConsumeFuel();
        }
        public void BrakeBy(int deceleration)
        {
            if (!_engine.IsRunning) return;

            _speed = Math.Max(_speed - Math.Min(deceleration, MAX_DECELERATION), 0);
            ConsumeFuel();
        }

        private void Move()
        {
            if (_speed > 0)
            {
                _speed = Math.Max(_speed - 1, 0); 
            }

            ConsumeFuel();
        }

        private void ConsumeFuel()
        {
            double consumptionRate = CalculateFuelConsumptionRate();
            _fuelTank.Consume(consumptionRate);
        }

        private double CalculateFuelConsumptionRate()
        {
            if (_speed >= 1 && _speed <= 60)
            {
                return 0.0020;
            }
            else if (_speed >= 61 && _speed <= 100)
            {
                return 0.0014;
            }
            else if (_speed >= 101 && _speed <= 140)
            {
                return 0.0020;
            }
            else if (_speed >= 141 && _speed <= 200)
            {
                return 0.0025;
            }
            else if (_speed >= 201 && _speed <= 250)
            {
                return 0.0030;
            }
            else
            {
                return 0;
            }
        }
    }
}
