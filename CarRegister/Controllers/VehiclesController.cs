using CarRegister.Data;
using CarRegister.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public VehiclesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehilcle()
        {
            if (_appDbContext.Vehicles == null)
            {
                return NotFound();
            }
            return await _appDbContext.Vehicles.ToListAsync();
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            if (_appDbContext.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _appDbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            _appDbContext.Vehicles.Add(vehicle);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.ID }, vehicle);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> EditVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.ID)
            {
                return BadRequest();
            }

            _appDbContext.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            if (_appDbContext.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _appDbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _appDbContext.Vehicles.Remove(vehicle);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
