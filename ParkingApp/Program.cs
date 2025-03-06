using ParkingApp.blueprint;
using System;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle newVehicle = new("111", "red", constant.VehicleType.MOTORCYCLE);
            Console.WriteLine(newVehicle.Color);

            ParkingLot parkingLot = new(10);
            Console.WriteLine(parkingLot.TotalSlots);
        }
    }
}
