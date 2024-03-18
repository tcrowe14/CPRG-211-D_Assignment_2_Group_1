using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

// CPRG-211-D
// Group 1 Assignment 2
// March 18 2024

namespace Assignment2.Components.Pages.Data
{
    internal class ReservationManager
    {
        private static string ReservationText = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:/Maui/Assignment2Final/CPRG-211-D_Assignment_2_Group_1/Resources/Files/reservation.csv");

        private static Random random = new Random();
        
        private static List<Reservation> reservations = new List<Reservation>();

        public List<Reservation> FindReservations(string reservationCode, string airline, string name)
        {
            return reservations.Where(r =>
                (string.IsNullOrEmpty(reservationCode) || r.Code.Contains(reservationCode)) &&
                (string.IsNullOrEmpty(airline) || r.Airline.Contains(airline)) &&
                (string.IsNullOrEmpty(name) || r.Name.Contains(name))
            ).ToList();
        }

        // Calls method to generate reservation code
        public string GenerateResCode()
        {
            return GenerateReservationCode();
        }

        // Generates a random reservation code that always starts with A
        public string GenerateReservationCode()
        {
            string reservationCode;

            do
            {
                char letter = (char)('A' + random.Next(26));
                string numbers = random.Next(1000, 10000).ToString();
                reservationCode = letter + numbers;
            } while (IsCodeGenerated(reservationCode, ReservationText));

            return reservationCode;
        }

        // Checks and returns to see if a reservation code is generated
        private static bool IsCodeGenerated(string reservationCode, string ReservationText)
        {
            if (!File.Exists(reservationCode))
            {
                return false;
            }

            List<string> existingCode = File.ReadAllLines(ReservationText).ToList();

            return existingCode.Contains(reservationCode);
        }

        // Fetches data from the csv file and builds a reservation on the split data adding to the list
        public static List<Reservation> GetReservations()
        {
            List<Reservation> res = new List<Reservation>();
            foreach (string line in File.ReadLines(ReservationText))
            {
                string[] parts = line.Split(",");
                string reservationCode = parts[0];
                string flightCode = parts[1];
                string airline = parts[2];
                double cost = double.Parse(parts[3]);
                string name = parts[4];
                string citizenship = parts[5];
                string status = parts[6];

                Reservation newReservation = new Reservation(reservationCode, flightCode, airline, cost, name, citizenship, status);
                res.Add(newReservation);
            }
            reservations = res;
            return res;
        }

        // Adds the reservation into the end of the csv file
        public void AddReservation(Reservation res)
        {
            File.AppendAllText(ReservationText, $"{res.Code},{res.FlightCode},{res.Airline},{res.Cost},{res.Name},{res.Citizenship},{res.Active}\n");
        }

        // Adds all the curent reservations and writes into the csv file
        public void UpdateReservation(Reservation res)
        {
            var lines = File.ReadAllLines(ReservationText).ToList();
            var index = lines.FindIndex(line => line.StartsWith(res.Code));
            if (index != -1)
            {
                lines[index] = $"{res.Code},{res.FlightCode},{res.Airline},{res.Cost},{res.Name},{res.Citizenship},{res.Active}";
            }

            File.WriteAllLines(ReservationText, lines);
        }
    }
}