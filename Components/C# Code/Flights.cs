using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// CPRG-211-D
// Group 1 Assignment 2
// March 18 2024

namespace Assignment2.Components.Pages.Data
{
    internal class Flight
    {
        public const int RecordSize = 72;

        private string code;

        private string airline;

        private string from;

        private string to;

        private string weekday;

        private string time;


        private int seats;

        private double costPerSeat;

        // 
        public Flight(string code)
        {
            this.code = code;
        }
        // 
        public Flight(string code, string airline, string from, string to, string weekday, string time, int seats, double costPerSeat)
        {
            this.code = code;
            this.airline = airline;
            this.from = from;
            this.to = to;
            this.weekday = weekday;
            this.time = time;
            this.seats = seats;
            this.costPerSeat = costPerSeat;

        }

        public string Code { get => code; set => code = value; }
        public string Airline { get => airline; set => airline = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Weekday { get => weekday; set => weekday = value; }
        public string Time { get => time; set => time = value; }
        public int Seats { get => seats; set => seats = value; }
        public double CostPerSeat { get => costPerSeat; set => costPerSeat = value; }


    }
}

