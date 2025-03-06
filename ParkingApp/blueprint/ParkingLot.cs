using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.blueprint
{
    class ParkingLot
    {
        public Int16 TotalSlots { get; private set; }
        public Dictionary<int, Vehicle> OccupiedLots { get; private set; }

        public ParkingLot(Int16 totalSlots)
        {
            TotalSlots = totalSlots;
            OccupiedLots = new();
        }
    }
}
