using System.ComponentModel.DataAnnotations;

namespace Flights7.Domain.Entities
{
    public record Booking(
        string PassengerEmail,
        byte NumberOfSeats);
}
