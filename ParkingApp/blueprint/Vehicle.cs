﻿using ParkingApp.constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.blueprint
{
    class Vehicle
    {
        public String RegistrationNumber { get; set; }
        public String Color { get; set; }
        private VehicleType Type { get; set; }

        public Vehicle(string registrationNumber, string color, VehicleType type)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Type = type;
        }
    }
}
