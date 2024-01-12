namespace Svb.Test.Models
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
            FindOptionsRecursive(numberOfGuests, roomTypeOptions:[], options);

            var cheapestOption = options?.OrderBy(option => option.TotalPrice).FirstOrDefault();

            return cheapestOption != null ?
                $"{string.Join(" ", cheapestOption.RoomTypes)} - ${cheapestOption.TotalPrice}"
                : "No option";
        }

        private void FindOptionsRecursive(int guests, 
            List<string> roomTypeOptions, 
            List<ReservationOption> result)
        {
            if (guests == 0)
            {
                var totalPrice = roomTypeOptions
                    .Sum(roomType => _rooms.First(room => room.Type == roomType).Price);

                result.Add(new ReservationOption([.. roomTypeOptions], totalPrice));
                return;
            }

            foreach (var room in _rooms)
            {
                var currentNumberOfRoomType = roomTypeOptions.Count(roomType => roomType == room.Type);
                if (guests >= room.AvailableGuests && currentNumberOfRoomType < room.NumberOfRooms)
                {
                    roomTypeOptions.Add(room.Type);

                    var remainingGuests = guests - room.AvailableGuests;
                    FindOptionsRecursive(remainingGuests, roomTypeOptions, result);

                    roomTypeOptions.RemoveAt(roomTypeOptions.Count - 1);
                }
            }
        }
    }
}
