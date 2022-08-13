//-----------------------------------------------------------------
// TacoParser Exercise
//
// Name: David Zientara
// Date: 8-13-2022
// Comments: An exercise in parsing a CSV
// Made changes per the instructions
// Make an ITrackable interface with a name + location
//----------------------------------------------------------------
namespace LoggingKata
{
    public interface ITrackable
    {
        string Name { get; set; }
        Point Location { get; set; }
    }
}