using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Dtos;

namespace WebApplication1.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    public static readonly List<Visit> Visits =
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
        if (relatedVisits.Count == 0)
        {
            return NotFound($"No visits found for animal with id {animalId}");
        }
        return Ok(relatedVisits);
    }

    [HttpPost("{animalId:int}")]
    public IActionResult CreateVisit(int animalId, [FromBody] VisitDto visitDto)
    {
        // Sprawdzenie, czy zwierzę z danym ID istnieje
        var animal = AnimalsController.Animals.FirstOrDefault(a => a.Id == animalId);
        if (animal == null)
        {
            return NotFound($"No animal found with ID {animalId}. Please create the animal first.");
        }

        // Utworzenie nowej wizyty
        var newVisit = new Visit
        {
            Id = Visits.Count + 1, 
            AnimalId = animalId,
            DateOfVisit = visitDto.VisitDate,
            Description = visitDto.VisitDescription,
            VisitPrice = visitDto.VisitPrice
        };

        Visits.Add(newVisit);
        return CreatedAtAction("GetVisit", new { id = newVisit.Id }, newVisit);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisit(int id)
    {
        var visit = Visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
        {
            return NotFound($"Nie znaleziono wizyty z podanym id: {id} ");
        }
        return Ok(visit);
    }

}


