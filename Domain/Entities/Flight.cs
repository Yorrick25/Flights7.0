using Flights7.ReadModels;
using Flights7.Domain.Entities;
using Flights7.Domain.Errors;

namespace Flights7.Domain.Entities
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string Price { get; set; }
        public TimePlace Departure { get; set; }
        public TimePlace Arrival { get; set; }
        public  int RemainingNumberOfSeats { get; set; }
        public IList<Booking> Bookings = new List<Booking>();

        public 
            Flight()
        {

        }

        public Flight(
            Guid id,
            string airline,
            string price,
            TimePlace departure,
            TimePlace arrival,
            int remainingNumberOfSeats
            )
        {
            Id = id;
            Airline= airline;
            Price = price;
            Departure = departure;
            Arrival = arrival;
            RemainingNumberOfSeats = remainingNumberOfSeats;
        }

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

        public object? CancelBooking(string passengerEmail, byte numberOfSeats)
        {
            var booking = Bookings.FirstOrDefault(b => numberOfSeats == b.NumberOfSeats 
                && passengerEmail.ToLower() == b.PassengerEmail.ToLower());

            if (booking == null)
            {
                return new NotFoundError();
            }

            Bookings.Remove(booking);
            RemainingNumberOfSeats += booking.NumberOfSeats;

            return null;
        }
    }

}
