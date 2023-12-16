namespace CarBuilder
{
    public interface IDrivingProcessor
    {
        int ActualSpeed { get; set; }
        void IncreaseSpeedTo(int speed);
        void ReduceSpeed(int speed);
        void AccelerateTo(int speed);
        void BrakeBy(int amount);
        void Move();
    }
}
