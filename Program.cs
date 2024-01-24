using Svb.Test.Common;

namespace Svb.Test;

public class Program
{
    static void Main()
    {
        IReservationManager reservationManager = new ReservationManager(
        [
            new(RoomType.Single, 1, 30),
            new(RoomType.Double, 2, 50),
            new(RoomType.Family, 4, 85)
        ]);

        Console.WriteLine(reservationManager.FindCheapestReservationOption(numberOfGuests: 2)?.ToString());
        //Console.WriteLine(reservationManager.FindCheapestReservationOption(numberOfGuests: 3)?.ToString());
        //Console.WriteLine(reservationManager.FindCheapestReservationOption(numberOfGuests: 20)?.ToString());
    }
}
