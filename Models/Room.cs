using System.Diagnostics;

namespace Svb.Test.Models;

[DebuggerDisplay("{Type}")]
public class Room(string roomType, int sleeps, int numberOfRooms, int price)
{
    public string Type { get; } = roomType;
    public int AvailableGuests { get; } = sleeps;
    public int NumberOfRooms { get; set; } = numberOfRooms;
    public int Price { get; } = price;

    public bool IsAvailable => NumberOfRooms > 0;
}