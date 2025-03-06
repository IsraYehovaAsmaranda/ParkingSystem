using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.blueprint
{
    class ParkingLot
    {
        public int TotalSlots { get; private set; }
        public Dictionary<int, Vehicle> OccupiedLots { get; private set; }

        public ParkingLot(int totalSlots)
        {
            TotalSlots = totalSlots;
            OccupiedLots = new();
        }

        public String Park(Vehicle vehicle)
        {
            if(OccupiedLots.Count >= TotalSlots)
            {
                return "Sorry, parking lot is full";
            }
            int slotNumber = Enumerable.Range(1, TotalSlots).FirstOrDefault(i => !OccupiedLots.ContainsKey(i));
            OccupiedLots[slotNumber] = vehicle;
            return $"Allocated slot number: {slotNumber}";
        }
    }
}
