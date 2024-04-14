using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/vists")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> _visits = new()
    {
        new Visit{IdVisit = 1, VisitDate = new DateTime(2024, 3, 10), AnimalId = 1, Description = "Zastrzyk przeciw kleszczom - 1 dawka", Price = 150},
        new Visit{IdVisit = 2, VisitDate = new DateTime(2024, 3, 22), AnimalId = 1, Description = "Zastrzyk przeciw kleszczom - 2 dawka", Price = 120},
        new Visit{IdVisit = 3, VisitDate = new DateTime(2024, 4, 12), AnimalId = 2, Description = "Ogólna kontrola", Price = 99.90}
    };
    
    [HttpGet("{animalId:int}")]
    public IActionResult GetVisits(int animalId)
    {
        var visits = _visits.Where(visit => visit.AnimalId == animalId).ToList();
        if (visits == null)
        {
            return NotFound($"Animal with id {animalId} had no visits before");
        }

        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}