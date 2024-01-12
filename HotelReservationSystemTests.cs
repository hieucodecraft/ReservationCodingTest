using Xunit;

namespace Svb.Test
{
    public class HotelReservationSystemTests
    {
        private HotelReservationSystem reservationSystem;

        public HotelReservationSystemTests()
        {
            reservationSystem = new HotelReservationSystem();
        }

        [Fact]
        public void MakeReservation_WithThreeGuests_ReturnsExpectedResult()
        {
            var result = reservationSystem.MakeReservation(3);
            Assert.Equal("Single Double - $80", result);
        }

        [Fact]
        public void MakeReservation_WithSixGuests_ReturnsExpectedResult()
        {
            var result = reservationSystem.MakeReservation(6);
            Assert.Equal("Family Double - $135", result);
        }

        [Fact]
        public void MakeReservation_WithNoAvailableRooms_ReturnsNoOption()
        {
            var result = reservationSystem.MakeReservation(10);
            Assert.Equal("No option", result);
        }
    }
}
