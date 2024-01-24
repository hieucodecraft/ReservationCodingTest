using System.Diagnostics;

namespace Svb.Test.Models;

[DebuggerDisplay("{Type}")]
public class Room(string roomType, int sleeps,int price)
{
    public string Type { get; } = roomType;
    public int AvailableGuests { get; } = sleeps;
    public int Price { get; } = price;
}