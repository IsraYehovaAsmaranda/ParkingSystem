using ParkingApp.blueprint;
using System;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new(5, 3000);
            Console.WriteLine(parkingLot.TotalLots);

            Vehicle newVehicle = new("XZX-1029-XKXO", "red", constant.VehicleType.MOTOR);
            Vehicle newVehicle2 = new("XZX-1030-XKXO", "red", constant.VehicleType.MOTOR);
            Console.WriteLine(parkingLot.CheckIn(newVehicle));
            Console.WriteLine(parkingLot.CheckIn(newVehicle));
            Console.WriteLine(parkingLot.CheckIn(newVehicle));
            Console.WriteLine(parkingLot.CheckIn(newVehicle2));
            Console.WriteLine(parkingLot.CheckIn(newVehicle2));

            Console.WriteLine(parkingLot.CheckOut(2));
            Console.WriteLine(parkingLot.CheckOut(3));

            Console.WriteLine(parkingLot.Status());

            Console.WriteLine(parkingLot.GetEvenRegistrationNumber());
            Console.WriteLine(parkingLot.GetOddRegistrationNumber());
        }
    }
}
