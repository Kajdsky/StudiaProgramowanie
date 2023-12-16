using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public interface IFuelTankDisplay
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
    }
}
