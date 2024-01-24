using Svb.Test.Common;
using Svb.Test.Models;

namespace Svb.Test
{
    public interface IReservationManager
    {
        ReservationOption? FindCheapestReservationOption(int numberOfGuests);
    }

    public class ReservationManager(List<Room> rooms) : IReservationManager
    {
        private readonly List<Room> _rooms = rooms;
        private readonly Dictionary<string, int> _numberOfRooms = new()
        {
            { RoomType.Single, 2 }, 
            { RoomType.Double, 3 }, 
            { RoomType.Family, 1 } 
        };

        public ReservationOption? FindCheapestReservationOption(int numberOfGuests)
        {
            var options = new List<ReservationOption>();
            FindOptionsRecursive(numberOfGuests, availableOptions: [], options);
            var cheapestOption = options?.OrderBy(option => option.TotalPrice).FirstOrDefault();

            return cheapestOption;
        }

        private void FindOptionsRecursive(
            int guests,
            List<string> availableOptions,
            List<ReservationOption> result)
        {
            if (guests == 0)
            {
                var totalPrice = availableOptions.Sum(roomType => _rooms.First(room => room.Type == roomType).Price);
                result.Add(new ReservationOption([.. availableOptions], totalPrice));
                return;
            }

            foreach (var room in _rooms)
            {
                int matchingRoomTypeCount = availableOptions.Count(roomType => roomType == room.Type);
                if (guests >= room.AvailableGuests && matchingRoomTypeCount < _numberOfRooms[room.Type])
                {
                    availableOptions.Add(room.Type);

                    var remainingGuests = guests - room.AvailableGuests;
                    FindOptionsRecursive(remainingGuests, availableOptions, result);

                    availableOptions.RemoveAt(availableOptions.Count - 1);
                }
            }
        }
    }
}
