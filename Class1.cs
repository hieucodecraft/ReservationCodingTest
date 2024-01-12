using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Svb.Test;

public class HotelRoom
{
    public string RoomType { get; set; }
    public int Sleeps { get; set; }
    public int NumberOfRooms { get; set; }
    public decimal Price { get; set; }
}

public class HotelReservationSystem
{
    private List<HotelRoom> rooms;

    public HotelReservationSystem()
    {
        // Initialize hotel rooms
        rooms = new List<HotelRoom>
        {
            new HotelRoom { RoomType = "Single", Sleeps = 1, NumberOfRooms = 2, Price = 30 },
            new HotelRoom { RoomType = "Double", Sleeps = 2, NumberOfRooms = 3, Price = 50 },
            new HotelRoom { RoomType = "Family", Sleeps = 4, NumberOfRooms = 1, Price = 85 }
        };
    }

    public string MakeReservation(int numberOfGuests)
    {
        // Find available options
        var options = FindOptions(numberOfGuests);

        // Choose the cheapest option
        var cheapestOption = options.OrderBy(o => o.TotalPrice).FirstOrDefault();

        if (cheapestOption != null)
        {
            return $"{string.Join(" ", cheapestOption.RoomTypes)} - ${cheapestOption.TotalPrice}";
        }
        else
        {
            return "No option";
        }
    }

    private List<ReservationOption> FindOptions(int numberOfGuests)
    {
        var result = new List<ReservationOption>();
        FindOptionsRecursive(numberOfGuests, new List<string>(), result);
        return result;
    }

    private void FindOptionsRecursive(int guests, List<string> currentOption, List<ReservationOption> result)
    {
        if (guests == 0)
        {
            decimal totalPrice = currentOption.Sum(roomType => rooms.First(room => room.RoomType == roomType).Price);
            result.Add(new ReservationOption
            {
                RoomTypes = [.. currentOption],
                TotalPrice = totalPrice
            });

            return;
        }

        foreach (var room in rooms)
        {
            var currentNumberOfRoomType = currentOption.Count(roomType => roomType == room.RoomType);
            if (guests >= room.Sleeps && currentNumberOfRoomType < room.NumberOfRooms)
            {
                currentOption.Add(room.RoomType);

                var remainingGuests = guests - room.Sleeps;
                FindOptionsRecursive(remainingGuests, currentOption, result);

                currentOption.RemoveAt(currentOption.Count - 1);
            }
        }
    }
}

public class ReservationOption
{
    public List<string> RoomTypes { get; set; }
    public decimal TotalPrice { get; set; }
}

public class Program
{
    static void Main()
    {
        HotelReservationSystem reservationSystem = new();

        // Examples
        Console.WriteLine(reservationSystem.MakeReservation(2));
        Console.WriteLine(reservationSystem.MakeReservation(3));
        Console.WriteLine(reservationSystem.MakeReservation(6));
    }
}
