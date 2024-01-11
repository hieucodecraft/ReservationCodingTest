using System.Diagnostics;

namespace Svb.Test.Models;

[DebuggerDisplay("{RoomTypes} - {TotalPrice}")]
public class ReservationOption(List<string> roomTypes, decimal totalPrice)
{
    public List<string> RoomTypes { get; set; } = roomTypes;
    public decimal TotalPrice { get; set; } = totalPrice;
}