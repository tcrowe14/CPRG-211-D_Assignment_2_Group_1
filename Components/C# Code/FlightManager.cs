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
    internal class FlightManager
    {

        public static string WeekdayAny = "Any";
        public static string WeekdaySunday = "Sunday";       
        public static string WeekdayMonday = "Monday";
        public static string WeekdayTuesday = "Tuesday";      
        public static string WeekdayWednesday = "Wednesday"; 
        public static string WeekdayThursday = "Thursday";
        public static string WeekdayFriday = "Friday";    
        public static string WeekdaySaturday = "Saturday";

        
        public static string FlightsText = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Maui\Assignment2Final\CPRG-211-D_Assignment_2_Group_1\Resources\Files\flights.csv");      
        public static string AirportsText = "C:/Maui/Assignment2Final/CPRG-211-D_Assignment_2_Group_1/Resources/Files/airports.csv";    

        // Declare List of flights
        public static List<Flight> flights = new List<Flight>();

        // Declare List of airports
        public static List<string> airports = new List<string>();

       
        // Populate both methods
        public FlightManager()
        {
            populateAirports();
            populateFlights();
        }

        // Finds airports by code
        public string findAirportByCode(string code)
        {
            foreach (string airport in airports)
            {
                if (airport.Equals(code))
                    return airport;
            }

            return null;
        }


        // Find flight by code
        public static Flight findFlightByCode(string code)
        {
            foreach (Flight flight in flights)
            {
                if (flight.Code.Equals(code))
                    return flight;
            }

            return null;
        }


        // Finds flights based on selected inputs
        public static List<Flight> findFlights(string from, string to, string weekday)
        {
            return flights.Where(f =>
                (from == WeekdayAny || f.From.Equals(from)) &&
                (to == WeekdayAny || f.To.Equals(to)) &&
                (weekday == WeekdayAny || f.Weekday.Equals(weekday))
            ).ToList();


        }


        // Populates flights from the csv file
        private void populateFlights()
        {
            flights.Clear();
            try
            {
                int counter = 0;
                Flight flight;

                foreach (string line in File.ReadLines(FlightsText)) // Reads file
                {
                    Console.WriteLine(line);

                    string[] parts = line.Split(","); // Splits the csv file into parts and adds to variables

                    string code = parts[0];
                    string airline = parts[1];
                    string from = parts[2];
                    string to = parts[3];
                    string weekday = parts[4];
                    string time = parts[5];
                    int seatsAvailable = short.Parse(parts[6]);
                    double pricePerSeat = double.Parse(parts[7]);
                    string fromAirport = findAirportByCode(from);
                    string toAirport = findAirportByCode(to);

                    try
                    {
                        flight = new Flight(code, airline, fromAirport, toAirport, weekday, time, seatsAvailable, pricePerSeat);

                        flights.Add(flight);
                    }
                    catch (Exception e) //InvalidFlightCodeException
                    {

                    }

                    counter++;
                }
            }
            catch (Exception e)
            {

            }
        }


       // Populates airports from  the csv file
        private void populateAirports()
        {
            try
            {
                int counter = 0;
                foreach (string line in File.ReadLines(AirportsText))
                {
                    string[] parts = line.Split(",");

                    string code = parts[0];
                    string name = parts[1];
                    airports.Add(code);

                    counter++;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}

