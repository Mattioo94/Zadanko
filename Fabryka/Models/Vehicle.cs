using System.Threading;

namespace Fabryka.Models
{
    abstract class Vehicle : IVehicle
    {
        public int Time { get; set; }
        public int Expense { get; set; }

        public virtual void Build()
        {
            Thread.Sleep(Time * 1000);
        }
    }
}
