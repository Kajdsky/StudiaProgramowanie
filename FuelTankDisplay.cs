using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel => _fuelTank.FillLevel;

        public bool IsOnReserve => _fuelTank.IsOnReserve;
        private readonly IFuelTank _fuelTank;
        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }
    }
}
