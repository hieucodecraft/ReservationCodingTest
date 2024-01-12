using Svb.Test.Models;

namespace Svb.Test
{
    public interface IReservationManager
    {
        string FindAvailableReservationOptions(int numberOfGuests);
    }

    public class ReservationManager(List<Room> rooms) : IReservationManager
    {
        private readonly List<Room> _rooms = rooms;

        public string FindAvailableReservationOptions(int numberOfGuests)
        {
            var options = new List<ReservationOption>();
            FindOptionsRecursive(numberOfGuests, availableOptions: [], options);

            var cheapestOption = options?.OrderBy(option => option.TotalPrice).FirstOrDefault();

            return cheapestOption != null ?
                $"{string.Join(" ", cheapestOption.RoomTypes)} - ${cheapestOption.TotalPrice}"
                : "No option";
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
                var currentNumberOfRoomType = availableOptions.Count(roomType => roomType == room.Type);
                if (guests >= room.AvailableGuests && currentNumberOfRoomType < room.NumberOfRooms)
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
