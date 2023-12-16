using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public interface ICar
    {
        public int Id { get; set; }
        bool EngineIsRunning { get; }
        void EngineStart();
        void EngineStop();
        void Refuel(double liters);
        void RunningIdle();
    }
}
