﻿using Svb.Test.Common;

namespace Svb.Test.Models
{
    public class HotelReservationSystem
    {
        private readonly List<Room> rooms;
        private readonly IReservationManager _reservationManager;

        public HotelReservationSystem()
        {
            rooms =
            [
                new(RoomType.Single, 1, 2, 30),
                new(RoomType.Double, 2, 3, 50),
                new(RoomType.Family, 4, 1, 85)
            ];

            _reservationManager = new ReservationManager(rooms);
        }

        public string HandleReservationBooking(int numberOfGuests)
        {
            var options = _reservationManager.FindAvailableReservationOptions(numberOfGuests);
            if (options.Count == 0)
            {
                return "No option";
            }

            var cheapestOption = options.OrderBy(option => option.TotalPrice).First();
            return $"{string.Join(" ", cheapestOption.RoomTypes)} - ${cheapestOption.TotalPrice}";
        }
    }
}