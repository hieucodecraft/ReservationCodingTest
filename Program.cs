using Svb.Test.Common;
using Svb.Test.Models;

namespace Svb.Test;

public class Program
{
    static void Main()
    {
        IReservationManager reservationManager = new ReservationManager(
        [
            new(RoomType.Single, 1, 2, 30),
            new(RoomType.Double, 2, 3, 50),
            new(RoomType.Family, 4, 1, 85)
        ]);

        Console.WriteLine(reservationManager.FindAvailableReservationOptions(numberOfGuests: 2));
        //Console.WriteLine(reservationManager.FindAvailableReservationOptions(numberOfGuests: 3));
        //Console.WriteLine(reservationManager.FindAvailableReservationOptions(numberOfGuests: 6));
    }
}
