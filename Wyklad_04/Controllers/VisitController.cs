using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> Visits =
    [
        new Visit
        {
            Id = 1, AnimalId = 3, DateOfVisit = new DateTime(02 / 02 / 2024), Description = "szczepienie",
            VisitPrice = 150
        },

        new Visit
        {
            Id = 2, AnimalId = 1, DateOfVisit = new DateTime(04 / 22 / 2022), Description = "odrobaczenie",
            VisitPrice = 250
        },

        new Visit
        {
            Id = 3, AnimalId = 1, DateOfVisit = new DateTime(04 / 22 / 2022), Description = "szczepienie",
            VisitPrice = 250
        },

        new Visit
        {
            Id = 4, AnimalId = 2, DateOfVisit = new DateTime(24 / 01 / 2020), Description = "niestrawność",
            VisitPrice = 350
        }


    ];
    [HttpGet("animal/{animalId:int}")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var relatedVisits = Visits.Where(v => v.AnimalId == animalId).ToList();
        if (!relatedVisits.Any())
        {
            return NotFound($"No visits found for animal with id {animalId}");
        }
        return Ok(relatedVisits);
    }

    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        Visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}