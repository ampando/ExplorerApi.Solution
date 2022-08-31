using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExplorerApi.Models;

namespace ExplorerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ExplorerApiContext _db;

        public PlacesController(ExplorerApiContext db)
        {
            _db = db;
        }

    // GET: api/Places
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Place>>> Get(string city, string name, int rating)
    {
    var query = _db.Places.AsQueryable();

    if (city != null)
    {
        query = query.Where(entry => entry.City == city);
    }

        if (name != null)
    {
        query = query.Where(entry => entry.Name == name);
    }
    
        if (rating != 0)
    {
        query = query.Where(entry => entry.Rating >= rating);
        }
        return await query.ToListAsync();
    }
    
    // GET: api/Places/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
        var place = await _db.Places.FindAsync(id);

        if (place == null)
        {
            return NotFound();
        }

        return place;
    }
    
    // PUT: api/Places/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Place place)
    {
        if (id != place.PlaceId)
    {
        return BadRequest();
    }

        _db.Entry(place).State = EntityState.Modified;

    try
    {
        await _db.SaveChangesAsync();
    }
        catch (DbUpdateConcurrencyException)
    {
        if (!PlaceExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

        return NoContent();
    }
    // POST api/places
    [HttpPost]
    public async Task<ActionResult<Place>> Post(Place place)
    {
        _db.Places.Add(place);
        await _db.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = place.PlaceId }, place);
    }

    // DELETE: api/Places/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlace(int id)
    {
        var place = await _db.Places.FindAsync(id);
        if (place == null)
        {
            return NotFound();
        }

    _db.Places.Remove(place);
    await _db.SaveChangesAsync();

    return NoContent();
    }

    private bool PlaceExists(int id)
    {
        return _db.Places.Any(e => e.PlaceId == id);
    }
    }
}
