// Program 1A
// CIS 200-01
// Fall 2018
// Due: 9/24/2018
// By: Andrew L. Wright (students use Grading ID)

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Lester Joy", "156 Hunters Place", 
                "Benton", "KY", 40114);  // Test Address 5
            Address a6 = new Address("Ben Polly", "67 Young Street",
                "Danville", "CA", 92108);  // Test Address 6
            Address a7 = new Address("Hillary Mont", "791 Prog Ave",
                "Polar", "AL", 56123);     // Test Address 7
            Address a8 = new Address("Monica Key", "091 Mice Ave", 
                "Welro", "MI", 40981);     // Test Address 8


            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new Letter(a8, a6, 8.67M);

            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a5, a7, 65, 43, 87, 115);

            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a2, a3, 34, 23, 56, 
                180, 9.80M);

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                300, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a5, a8, 40.5, 45.3, 82.5,
                400, TwoDayAirPackage.Delivery.Early);


            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();
            
            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            //Query that sorts destination zips in descending order
               var sortZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            Console.WriteLine("Parcels by descending Destination Address");
            Console.WriteLine("====================");

            //displays the results of all parcels but zips are
            //in descending order
            foreach (Parcel p in sortZip)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            //Query sorts cost of packages in ascending order
            var costAsc =
                from p in parcels
                orderby p.CalcCost() ascending
                select p;
            Console.WriteLine("Parcels by ascending Cost");
            Console.WriteLine("====================");

            //displays cost of packages in ascending order
            foreach (Parcel p in costAsc)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            //Query orders by Parcel type (ascending) and then cost (descending)
            var parcelType =
                from p in parcels
                orderby p.GetType().ToString() ascending, p.CalcCost() descending
                select p;

            Console.WriteLine("Parcels by ascending Parcel Type and " +
                "descending Cost");
            Console.WriteLine("====================");

            //displays Parcel Type (ascending and Cost (descending)
            foreach (Parcel p in parcelType)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");

            }
            Pause();

            var isHeavy =
                from AirPackage in parcels
                orderby AirPackage
                
                

        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
