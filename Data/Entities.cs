using Flights7.Domain.Entities;
using System;

namespace Flights7.Data
{
    public class Entities
    {
        public IList<Passenger> Passengers = new List<Passenger>();
        public List<Flight> Flights = new List<Flight>();
    }
}
