using System.ComponentModel.DataAnnotations;

namespace Flights7.Domain.Entities
{
    public record Booking(
        Guid FlightId,
        string PassengerEmail,
        byte NumberOfSeats);
}
