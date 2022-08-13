using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using GeoCoordinatePortable;
//using GeoCoordinatePortable;
//-----------------------------------------------------------------
// TacoParser Exercise
//
// Name: David Zientara
// Date: 8-13-2022
// Comments: An exercise in parsing a CSV
// Made changes per the instructions
//----------------------------------------------------------------
namespace LoggingKata
{
    class Program
    {
        // Initialize some variables, includding a logger,
        // two objects representing two TacoBell locations
        // that are farthest apart, and a variable representing
        // the farthest distance:
        static readonly ILog logger = new TacoLogger(); // logger
        const string csvPath = "TacoBell-US-AL.csv"; // the filename
        static TacoBell farthestA = new TacoBell(); // Two locations are farthest apart; this is one
        static TacoBell farthestB = new TacoBell(); // This is the other
        static double farthestDistance = 0.0; // The farthest distance
        static TacoBell closestA = new TacoBell(); // Two locations are farthest apart; this is one
        static TacoBell closestB = new TacoBell(); // This is the other
        static double closestDistance = -1;
        static string[] lines;

        static void Main() //string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------
            int i, j;
            
            bool fileValid = false;
            logger.LogInfo("Log initialized");



            do
            {
                Console.Write($"Enter filename [{csvPath}]:");

                string filename = Console.ReadLine();

                if (filename == "")
                {
                    filename = csvPath;
                }

                // use File.ReadAllLines(path) to grab all the lines from your csv file
                // Log and error if you get 0 lines and a warning if you get 1 line

                try
                {
                    fileValid = true;
                    lines = File.ReadAllLines(filename); // csvPath);
                    logger.LogInfo($"Lines: {lines[0]}");
                }
                catch (System.IO.FileNotFoundException) //Add FileNotFoundException
                {
                    Console.WriteLine("File not found or parsing error.");
                    fileValid = false;
                }
                catch (System.IO.FileLoadException) //The file could be found, but might not load
                {
                    Console.WriteLine("Error loading file.");
                    fileValid = false;
                }
                catch (System.NullReferenceException) //This seems to be an exception that crops up often
                {
                    Console.WriteLine("Null reference exception.");
                    fileValid= false;
                }
                catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
                {
                    Console.WriteLine("Unknown error: " + ex.Message);
                }

                if (lines != null)
                {
                    if (lines.Length == 0)
                    {
                        logger.LogInfo($"Error reading {csvPath}");
                        fileValid = false;
                    }
                    else if (lines.Length == 1)
                    {
                        logger.LogInfo($"Error reading {csvPath} - only read one line");
                        fileValid = false;
                    }
                }
            } while (!fileValid);

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            // This makes more sense for me, too
            ITrackable[] locations = null;
            try
            {
                locations = lines.Select(x => parser.Parse(x)).ToArray();
            }
            catch (System.NullReferenceException) //NullReferenceException often happens
            {
                Console.WriteLine("Null reference exception.");
                return;
            }
            catch (Exception ex) // This is the generic catch-all exeception, included per your instructions
            {
                Console.WriteLine("Unknown error: " + ex.Message);
            }

            //List<TacoBell> list = lines.ToList().ForEach(); 

            //Tried doing this with ForEach, but it didn't work:
            ////TacoBell [] list = lines.ToList().ForEach(x => parser.Parse(x)).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------


            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            // ITrackable? LocA = null;
            // ITrackable? LocB = null;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            for (i = 0; i < locations.Length; i++)
                for (j = i+1; j < locations.Length; j++)
                {
                    //TacoBell BellA = new TacoBell();
                    TacoParser Parser = new TacoParser();

                    TacoBell locA = (TacoBell)locations[i]; 
                    TacoBell locB = (TacoBell)locations[j]; 

                    GeoCoordinate CoorA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                    GeoCoordinate CoorB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double distance = CoorA.GetDistanceTo(CoorB);
                    if (distance > farthestDistance)
                    {
                        farthestDistance = distance;
                        farthestA = locA;
                        farthestB = locB;

                    }
                    if (distance < closestDistance || closestDistance == -1)
                    {
                        closestDistance = distance;
                        closestA = locA;
                        closestB = locB;

                    }

                }
             
            

            Console.WriteLine($"The two Taco Bells that are farthest away from each other are:");
            Console.WriteLine($"{farthestA.Name} and {farthestB.Name}");
            Console.WriteLine($"Distance: {farthestDistance}");
            Console.WriteLine($"The two Taco Bells that are closest to each other are:");
            Console.WriteLine($"{closestA.Name} and {closestB.Name}");
            Console.WriteLine($"Distance: {closestDistance}");
            Console.WriteLine($"Parsed {locations.Length} locations.");

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
