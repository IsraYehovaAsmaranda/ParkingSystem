using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ParkingApp.constant;

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
            Console.WriteLine($"Created a parking lot with {totalSlots} slots");
        }

        public String CheckIn(Vehicle vehicle)
        {
            if (OccupiedLots.Count >= TotalLots)
            {
                return "Sorry, parking lot is full";
            }
            int slotNumber = Enumerable
                .Range(1, TotalLots)
                .FirstOrDefault(i => !OccupiedLots.ContainsKey(i));
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
            foreach (KeyValuePair<int, VehicleParkRequest> vehicleParkRequest in OccupiedLots)
            {
                result +=
                    $"{vehicleParkRequest.Key} \t\t {vehicleParkRequest.Value.Vehicle.Type} \t {vehicleParkRequest.Value.Vehicle.RegistrationNumber} \t\t {vehicleParkRequest.Value.Vehicle.Color}\n";
            }
            return result;
        }

        public int CountOccupiedSlots()
        {
            return OccupiedLots.Count;
        }

        public int CountAvailableSlots()
        {
            return TotalLots - OccupiedLots.Count;
        }

        public int CountByType(VehicleType type)
        {
            return OccupiedLots.Values.Where(v => v.Vehicle.Type == type).Count();
        }

        public int CountByColor(String color)
        {
            Dictionary<int, Vehicle> vehicles = FindByColor(color);
            return vehicles.Values.Count;
        }

        public int CountByEvenRegistrationNumber()
        {
            return OccupiedLots.Values.Count(v =>
                int.TryParse(
                    new string(v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()),
                    out int lastDigit
                )
                && lastDigit % 2 == 0
            );
        }

        public int CountByOddRegistrationNumber()
        {
            return OccupiedLots.Values.Count(v =>
                int.TryParse(
                    new string(v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()),
                    out int lastDigit
                )
                && lastDigit % 2 == 1
            );
        }

        public String GetEvenRegistrationNumber()
        {
            var evenRegistrationNumber = OccupiedLots
                .Values.Where(v =>
                    int.TryParse(
                        new string(
                            v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()
                        ),
                        out int lastDigit
                    )
                    && lastDigit % 2 == 0
                )
                .Select(v => v.Vehicle.RegistrationNumber);

            return evenRegistrationNumber.Any()
                ? String.Join(", ", evenRegistrationNumber)
                : "No vehicle with even registration number found";
        }

        public String GetOddRegistrationNumber()
        {
            var oddRegistrationNumber = OccupiedLots
                .Values.Where(v =>
                    int.TryParse(
                        new string(
                            v.Vehicle.RegistrationNumber.Where(char.IsDigit).Last().ToString()
                        ),
                        out int lastDigit
                    )
                    && lastDigit % 2 == 1
                )
                .Select(v => v.Vehicle.RegistrationNumber);

            return oddRegistrationNumber.Any()
                ? String.Join(", ", oddRegistrationNumber)
                : "No vehicle with odd registration number found";
        }

        public String GetRegistrationNumberByColor(String color)
        {
            Dictionary<int, Vehicle> vehicles = FindByColor(color);
            return String.Join(", ", vehicles.Select(v => v.Value.RegistrationNumber));
        }

        public String GetSlotNumberByColor(String color)
        {
            Dictionary<int, Vehicle> vehicles = FindByColor(color);
            return String.Join(", ", vehicles.Select(v => v.Key));
        }

        public String GetSlotNumberByRegistrationNumber(String registrationNumber)
        {
            try
            {
                Vehicle vehicles = FindByRegistrationNumber(registrationNumber);
                return vehicles.RegistrationNumber;
            } catch (Exception)
            {
                return "Not found";
            }
        }

        public Dictionary<int, Vehicle> FindByColor(String color)
        {
            return OccupiedLots
                .Where(v => v.Value.Vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(v => v.Key, v => v.Value.Vehicle);
        }

        public Vehicle FindByRegistrationNumber(String registrationNumber)
        {
            return OccupiedLots
                .Where(v =>
                    v.Value.Vehicle.RegistrationNumber.Equals(
                        registrationNumber,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .Select(v => v.Value.Vehicle)
                .FirstOrDefault();
        }
    }
}
