using Flights7.Domain.Entities;

namespace Flights7._0.Domain.Entities
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
    }

}
