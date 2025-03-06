using ParkingApp.blueprint;
using System;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new(2);
            Console.WriteLine(parkingLot.TotalSlots);

            Vehicle newVehicle = new("111", "red", constant.VehicleType.MOTORCYCLE);
            Console.WriteLine(parkingLot.Park(newVehicle));
            Console.WriteLine(parkingLot.Park(newVehicle));
            Console.WriteLine(parkingLot.Park(newVehicle));
        }
    }
}
