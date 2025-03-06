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
        public Dictionary<int, VehicleParkRequest> OccupiedLots { get; private set; }
        public Decimal RatePerHour { get; set; }

        public ParkingLot(int totalSlots, decimal ratePerHour)
        {
            TotalSlots = totalSlots;
            RatePerHour = ratePerHour;
            OccupiedLots = new();
        }

        public String CheckIn(Vehicle vehicle)
        {
            if(OccupiedLots.Count >= TotalSlots)
            {
                return "Sorry, parking lot is full";
            }
            int slotNumber = Enumerable.Range(1, TotalSlots).FirstOrDefault(i => !OccupiedLots.ContainsKey(i));
            VehicleParkRequest vehicleParkRequest = new(vehicle);
            OccupiedLots[slotNumber] = vehicleParkRequest;
            return $"Allocated slot number: {slotNumber}";
        }
        public String CheckOut(int slotNumber)
        {
            if (!OccupiedLots.ContainsKey(slotNumber))
            {
                return $"Slot number {slotNumber} is free";
            }

            // Get Parking Price
            DateTime checkInTime = OccupiedLots.GetValueOrDefault(slotNumber).CheckInTime;
            TimeSpan parkTime = DateTime.Now.Subtract(checkInTime);
            int parkTimeHour = parkTime.Hours.Equals(0) ? 1 : parkTime.Hours;
            Decimal parkingPrice = parkTimeHour * RatePerHour;

            OccupiedLots.Remove(slotNumber);
            return $"Checkout price: {parkingPrice}. Slot number {slotNumber} is free";
        }
        
    }
}
