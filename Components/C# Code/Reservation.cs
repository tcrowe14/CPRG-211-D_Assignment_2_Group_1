using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CPRG-211-D
// Group 1 Assignment 2
// March 18 2024

namespace Assignment2.Components.Pages.Data
{
    internal class Reservation
    {
        public const int RecordSize = 201;

        // create variables
        private string code;
        private string flightCode;
        private string airline;
        private string name;
        private string citizenship;
        private double cost;
        private string active;
        private string reservationCode;
        private Flight flight;

        // Non parameterized constructor
        public Reservation()
        {
        }

        // Parameterized flight constructor method
        public Reservation(string code, string flightCode, string airline, double cost, string name, string citizenship, string active)
        {
            this.code = code;
            this.flightCode = flightCode;
            this.airline = airline;
            this.name = name;
            this.citizenship = citizenship;
            this.cost = cost;
            this.active = active;
        }

        // Parameterized reservation constructor method
        public Reservation(string reservationCode, Flight flight, string name, string citizenship)
        {
            this.reservationCode = reservationCode;
            this.flight = flight;
            this.name = name;
            this.citizenship = citizenship;
        }

        // Getters and setters
        public string Code { get => code; set => code = value; }
        public string FlightCode { get => flightCode; set => flightCode = value; }
        public string Airline { get => airline; set => airline = value; }
        public string Name { get => name; set => name = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Active { get => active; set => active = value; }

    }
}

