using Svb.Test.Models;
namespace Svb.Test;

public class Program
{
    static void Main()
    {
        HotelReservationSystem hotelReservationSystem = new();

        //Console.WriteLine("Enter the number of guests: ");
        //if (int.TryParse(Console.ReadLine(), out int numberOfGuests))
        //{
        //    string result = hotelReservationSystem.HandleBookingReservation(3);
        //    Console.WriteLine($"Output: {result}");
        //}
        //else
        //{
        //    Console.WriteLine("Invalid input. Please enter a valid number.");
        //}

        string result = hotelReservationSystem.HandleReservationBooking(6);
        Console.WriteLine($"Output: {result}");
    }
}
