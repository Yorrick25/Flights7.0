namespace Flights7.Dtos
{
    public record BookDto(Guid FlightId,
        string PassengerEmail,
        byte NumberOfSeats);
}
