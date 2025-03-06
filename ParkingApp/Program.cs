using System;
using ParkingApp.blueprint;
using ParkingApp.constant;

namespace ParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowCommands();
            ParkingLot parkingLot = null;
            while (true)
            {
                String input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;
                if (input == "exit")
                    break;
                string[] command = input.Split(" ");

                switch (command[0])
                {
                    case "show_commands":
                        ShowCommands();
                        break;
                    case "create_parking_lot":
                        try
                        {
                            parkingLot = new(int.Parse(command[1]), 3000);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "park":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(
                                parkingLot?.CheckIn(
                                    new Vehicle(
                                        command[1],
                                        command[2],
                                        Enum.Parse<VehicleType>(command[3], true)
                                    )
                                )
                            );
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "leave":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CheckOut(int.Parse(command[1])));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "status":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.Status());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "type_of_vehicles":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(
                                parkingLot?.CountByType(Enum.Parse<VehicleType>(command[1]))
                            );
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_ood_plate":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.GetOddRegistrationNumber());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_even_plate":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.GetEvenRegistrationNumber());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.GetRegistrationNumberByColor(command[1]));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "slot_numbers_for_vehicles_with_colour":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.GetSlotNumberByColor(command[1]));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "slot_number_for_registration_number":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(
                                parkingLot?.GetSlotNumberByRegistrationNumber(command[1])
                            );
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "count_vehicles_by_color":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CountByColor(command[1]));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "count_available_lots":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CountAvailableSlots());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "count_occupied_lots":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CountOccupiedSlots());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "count_even_plates":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CountByEvenRegistrationNumber());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    case "count_odd_plates":
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Parking lot has not been initialized");
                            break;
                        }
                        try
                        {
                            Console.WriteLine(parkingLot?.CountByOddRegistrationNumber());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Argument");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            }
        }
        static void ShowCommands()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("  Parking System - List of Available Commands  ");
            Console.WriteLine("=================================================");
            Console.WriteLine("create_parking_lot <jumlah_slot>");
            Console.WriteLine("park <nomor_registrasi> <warna> <jenis_kendaraan>");
            Console.WriteLine("leave <slot_number>");
            Console.WriteLine("status");
            Console.WriteLine("type_of_vehicles <jenis_kendaraan>");
            Console.WriteLine("registration_numbers_for_vehicles_with_odd_plate");
            Console.WriteLine("registration_numbers_for_vehicles_with_even_plate");
            Console.WriteLine("registration_numbers_for_vehicles_with_colour <warna>");
            Console.WriteLine("slot_numbers_for_vehicles_with_colour <warna>");
            Console.WriteLine("slot_number_for_registration_number <nomor_registrasi>");
            Console.WriteLine("count_vehicles_by_color <warna>");
            Console.WriteLine("count_available_lots");
            Console.WriteLine("count_occupied_lots");
            Console.WriteLine("count_even_plates");
            Console.WriteLine("count_odd_plates");
            Console.WriteLine("exit");
            Console.WriteLine("=================================================");
        }

    }
}
