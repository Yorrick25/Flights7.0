using Flights7.ReadModels;
using Flights7.Domain.Entities;
using Flights7.Domain.Errors;

namespace Flights7.Domain.Entities
{
    public record Flight(
        Guid Id,
        string Airline,
        string Price,
        TimePlace Departure,
        TimePlace Arrival,
        int RemainingNumberOfSeats
        )

    {
        public IList<Booking> Bookings = new List<Booking>();
        public int RemainingNumberOfSeats { get; set; } = RemainingNumberOfSeats;
        public object? MakeBooking(string passengerEmail, byte numberOfSeats)
        {
            var flight = this;

            //Making sure the flight is not getting overbooked.
            if (flight.RemainingNumberOfSeats < numberOfSeats)
            {
                return new OverbookError();
            }

            var booking = new Booking(
                passengerEmail,
                numberOfSeats);

            flight.Bookings.Add(booking);

            //Making sure flight doesnt get overbooked.
            flight.RemainingNumberOfSeats -= numberOfSeats;

            return null;
        }
    }

}
