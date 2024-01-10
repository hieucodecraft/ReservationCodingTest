namespace Svb.Test
{
    public enum RoomType
    {
        Single,
        Double,
        Family
    }

    public interface IRoom
    {
        RoomType Type { get; set; }
        int NumberAvailableGuests { get; set; }
        int Price { get; set; }
        int NumberOfRooms { get; set; }
    }

    public class SingleRoom(int guests, int numberOfRooms, int price) : IRoom
    {
        public RoomType Type { get ; set ; } = RoomType.Single;
        public int NumberAvailableGuests { get; set; } = guests;
        public int Price { get; set; } = price;
        public int NumberOfRooms { get; set; } = numberOfRooms;
    }

    public class DoubleRoom(int guests, int numberOfRooms, int price) : IRoom
    {
        public RoomType Type { get ; set ; } = RoomType.Double;
        public int NumberAvailableGuests { get; set; } = guests;
        public int Price { get; set; } = price;
        public int NumberOfRooms { get; set; } = numberOfRooms;
    }

    public class FamilyRoom(int guests, int numberOfRooms, int price) : IRoom
    {
        public RoomType Type { get ; set ; } = RoomType.Family;
        public int NumberAvailableGuests { get; set; } = guests;
        public int Price { get; set; } = price;
        public int NumberOfRooms { get; set; } = numberOfRooms;
    }

    public interface IRoomManager
    {
        List<IRoom> GetAvailableRooms(int guests);
    }

    public class RoomReservationManager(List<IRoom> rooms) : IRoomManager
    {
        private List<IRoom> CurrentRooms { get; set; } = rooms;

        public List<IRoom> GetAvailableRooms(int reservationGuests)
        {
            if (reservationGuests == 0 || reservationGuests > CurrentRooms.Sum(x => x.NumberAvailableGuests * x.NumberOfRooms))
            {
                return [];
            }

            var availableRooms = new List<IRoom>();
            if (reservationGuests == 1)
            {
                var isSingleRoomAvailable = CurrentRooms.Any(x => x.Type == RoomType.Single && x.NumberOfRooms > 0);
                if (isSingleRoomAvailable)
                {
                    var singleRoom = CurrentRooms.First(x => x.Type == RoomType.Single);
                    availableRooms.Add(singleRoom);
                    singleRoom.NumberOfRooms--;
                }   

                return availableRooms;
            }

            if (reservationGuests == 2)
            {
                var isDoubleRoomAvailable = CurrentRooms.Any(x => x.Type == RoomType.Double && x.NumberOfRooms > 0);
                if (isDoubleRoomAvailable)
                {
                    var doubleRoom = CurrentRooms.First(x => x.Type == RoomType.Double);
                    availableRooms.Add(doubleRoom);
                    doubleRoom.NumberOfRooms--;
                }   

                return availableRooms;
            }

            if (reservationGuests == 4)
            {
                var isFamilyRoomAvailable = CurrentRooms.Any(x => x.Type == RoomType.Family && x.NumberOfRooms > 0);
                if (isFamilyRoomAvailable)
                {
                    var familyRoom = CurrentRooms.First(x => x.Type == RoomType.Family);
                    availableRooms.Add(familyRoom);
                    familyRoom.NumberOfRooms--;
                }   

                return availableRooms;
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var guests = int.Parse(Console.ReadLine());
            var rooms = GetRooms();
            var roomManager = new RoomReservationManager(rooms);
            var availableRooms = roomManager.GetAvailableRooms(guests);
            string result = string.Empty;

            if (availableRooms.Count == 0)
            {
                result = "No option";
            }
            else
            {
                result = string.Join(", ", availableRooms.Select(x => x.Type.ToString()));
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static List<IRoom> GetRooms()
        {
            var rooms = new List<IRoom>
            {
                new SingleRoom(guests: 1, numberOfRooms: 2, price: 30),
                new DoubleRoom(guests: 2, numberOfRooms: 3, price: 50),
                new FamilyRoom(guests: 4, numberOfRooms: 1, price: 85)
            };

            return rooms;
        }   
    }
}
