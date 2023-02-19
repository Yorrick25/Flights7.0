using System.ComponentModel;

namespace Flights7.Dtos
{
    public record FlightSearchParameters(

        [DefaultValue("25/12/2022 10:30:00 AM")]
        DateTime? FromDate,

        [DefaultValue("26/12/2022 10:30:00 AM")]
        DateTime? ToDate,

        [DefaultValue("Los Angeles")]
        string? From,

        [DefaultValue("Berlin")]
        string? Destination,

        [DefaultValue(1)]
        int? NumberOfPassengers
        );
}

