namespace CarBuilder
{
    public interface IFuelTank
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
        void Consume(double liters);
        void Refuel(double liters);
        double CalculateFuelConsumption(int speed);
    }
}
