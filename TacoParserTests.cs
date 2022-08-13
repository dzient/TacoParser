using System;
using Xunit;
//-----------------------------------------------------------------
// TacoParser Exercise
//
// Name: David Zientara
// Date: 8-13-2022
// Comments: An exercise in parsing a CSV
// Made changes per the instructions
//----------------------------------------------------------------
// These are the tests for TDD
namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        //ShouldDoSomething
        //If the TacoParser works, it should not generate a null value
        // PARAMS: None
        // RETURNS: Nothing
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }
        //ShouldParseLongitude
        //If this works, we should get expected value for longitude
        // PARAMS: line (string): The line to parse
        //          expected (double): Expected longitude value
        // RETURNS: Nothing; should pass if expected == actual 
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParserInstance = new TacoParser();
            //Act
            var actual = tacoParserInstance.Parse("34.073638, -84.677017, Taco Bell Acwort...").Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }

        //ShouldParseLatitude
        //If this works, we should get expected value for latitude
        // PARAMS: line (string): The line to parse
        //          expected (double): Expected latitude value
        // RETURNS: Nothing; should pass if expected == actual 
        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var loc = tacoParser.Parse(line);
            double actual = loc.Location.Latitude;

            Assert.Equal(expected, actual);

        }
        
    }
}
