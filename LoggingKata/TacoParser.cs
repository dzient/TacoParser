namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    /// 
    //Create a TacoBell class that conforms to ITrackable
    //-----------------------------------------------------------------
    // TacoParser Exercise
    //
    // Name: David Zientara
    // Date: 8-13-2022
    // Comments: An exercise in parsing a CSV
    // Made changes per the instructions
    //----------------------------------------------------------------
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
    }
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        Point MyPoint = new Point();
        
        //Parse
        //Method takes a line, splits it into 3 pieces, and 
        //extracts latitude, longitude, and name
        //PARAMS: line (string): A line to parse
        //RETURNS: ITrackable object containing the name + location
        /// <param name="line"></param>
        /// <returns></returns>
        public ITrackable Parse(string line)
        {
            ///return null;
            logger.LogInfo("Begin parsing");
            
            TacoBell retval = new TacoBell();
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogWarning($"Parsing line {line} failed. Less than 3 items parsed.");
                return null; // TODO Implement
            }


            // grab the latitude from your array at index 0
            MyPoint.Latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            MyPoint.Longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2
            retval.Name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            retval.Location = MyPoint;


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return retval; // null;
        }
    }
}