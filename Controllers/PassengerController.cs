using Flights7.Data;
using Flights7.Domain.Entities;
using Flights7.Dtos;
using Flights7.ReadModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flights7.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly Entities _entities;

        public PassengerController(Entities entities)
        {
            _entities = entities;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register(NewPassengerDto dto)
        {
            var passenger = new Passenger(
                dto.Email,
                dto.FirstName,
                dto.LastName,
                dto.Gender);

            _entities.Passengers.Add(passenger);
            _entities.SaveChanges();
            return CreatedAtAction(nameof(Find), new { email = dto.Email});
        }

        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _entities.Passengers.FirstOrDefault(p => p.Email == email);
            if (passenger == null)
            {
                return NotFound();
            }

            var rm = new PassengerRm(
                passenger.Email,
                passenger.FirstName,
                passenger.LastName,
                passenger.Gender);

            return Ok(rm);
        }
    }
}
