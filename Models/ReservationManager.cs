namespace Svb.Test.Models
{
    public interface IReservationManager
    {
        List<ReservationOption> FindAvailableReservationOptions(int numberOfGuests);
    }

    public class ReservationManager(List<Room> rooms) : IReservationManager
    {
        private readonly List<Room> _rooms = rooms;

        public List<ReservationOption> FindAvailableReservationOptions(int numberOfGuests)
        {
            var reservationOptions = new List<ReservationOption>();
            GenerateOptions(numberOfGuests, reservationOptions);
            return reservationOptions;
        }

        private void GenerateOptions(int guests, List<ReservationOption> reservationOptions)
        {
            foreach (var room in _rooms)
            {
                if (guests >= room.AvailableGuests)
                {
                    int numberOfRoomsToBook = Math.Min(guests / room.AvailableGuests, room.NumberOfRooms);
                    int remainingGuest = guests - numberOfRoomsToBook * room.AvailableGuests;

                    if (remainingGuest > 0)
                    {
                        GenerateOptions(remainingGuest, reservationOptions);
                    }

                    var roomTypes = Enumerable.Repeat(room.Type, numberOfRoomsToBook).ToList();
                    var currentOption = new ReservationOption(roomTypes, numberOfRoomsToBook * room.Price);

                    reservationOptions.Add(currentOption);
                }
            }
        }
    }
}
