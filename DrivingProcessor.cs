using System;

namespace CarBuilder
{
    public class DrivingProcessor : IDrivingProcessor
    {
        public int ActualSpeed { get; set; }
        private const int MAX_SPEED = 250;
        private const int MAX_DECELERATION = 10;
        private int _acceleration;
        public DrivingProcessor(int acceleration = 10)
        {
            _acceleration = Math.Clamp(acceleration, 5, 20);
            ActualSpeed = 0;
        }
        public void IncreaseSpeedTo(int speed)
        {
            ActualSpeed = Math.Min(speed, MAX_SPEED);
        }
        public void ReduceSpeed(int speed)
        {
            ActualSpeed = Math.Max(ActualSpeed - speed, 0);
        }
        public void AccelerateTo(int speed)
        {
            var targetSpeed = Math.Min(speed, MAX_SPEED);
            ActualSpeed = Math.Min(ActualSpeed + _acceleration, targetSpeed);
        }
        public void BrakeBy(int amount)
        {
            ActualSpeed = Math.Max(ActualSpeed - Math.Min(amount, MAX_DECELERATION), 0);
        }
        public void Move()
        {
            if (ActualSpeed > 0)
            {
                ActualSpeed = Math.Max(ActualSpeed - 1, 0);
            }
        }
    }
}
