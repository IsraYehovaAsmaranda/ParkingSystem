using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingApp.blueprint
{
    class ParkingLot
    {
        public int TotalLots { get; private set; }
        public Dictionary<int, VehicleParkRequest> OccupiedLots { get; private set; }
        public Decimal RatePerHour { get; set; }

        public ParkingLot(int totalSlots, decimal ratePerHour)
        {
            TotalLots = totalSlots;
            RatePerHour = ratePerHour;
            OccupiedLots = new();
        }

        public String CheckIn(Vehicle vehicle)
        {
            if(OccupiedLots.Count >= TotalLots)
            {
                return "Sorry, parking lot is full";
            }
            int slotNumber = Enumerable.Range(1, TotalLots).FirstOrDefault(i => !OccupiedLots.ContainsKey(i));
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
        public String Status()
        {
            String result = "Slot No. \t Type \t Registration No. \t Colour\n";
            foreach(KeyValuePair<int, VehicleParkRequest> vehicleParkRequest in OccupiedLots)
            {
                result += $"{vehicleParkRequest.Key} \t\t {vehicleParkRequest.Value.Vehicle.Type} \t {vehicleParkRequest.Value.Vehicle.RegistrationNumber} \t\t {vehicleParkRequest.Value.Vehicle.Color}\n";
            }
            return result;
        }
        public int GetOccupiedSlotsCount()
        {
            return OccupiedLots.Count;
        }
        public int GetAvailableSlotsCount()
        {
            return TotalLots - OccupiedLots.Count;
        }
        public String GetEvenRegistrationNumber()
        {
            var evenRegistrationNumber = OccupiedLots.Values
                .Where(v => int.TryParse(new string(v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()), out int lastDigit) && lastDigit % 2 == 0)
                .Select(v => v.Vehicle.RegistrationNumber);

            return evenRegistrationNumber.Any() ? String.Join(", ", evenRegistrationNumber) : "No vehicle with even registration number found";
        }
        public String GetOddRegistrationNumber()
        {
            var oddRegistrationNumber = OccupiedLots.Values
                .Where(v => int.TryParse(new string(v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()), out int lastDigit) && lastDigit % 2 == 1)
                .Select(v => v.Vehicle.RegistrationNumber);

            return oddRegistrationNumber.Any() ? String.Join(", ", oddRegistrationNumber) : "No vehicle with odd registration number found";
        }
    }
}
