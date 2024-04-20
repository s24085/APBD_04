using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    
    private static readonly List<Animal> Animals=
    [
        new Animal { Id = 1, Name = "Rex", AnimalCategory = AnimalCategory.Kot, Weight = 20.4, FurColor = "grey" },
        new Animal { Id = 2, Name = "Fred", AnimalCategory = AnimalCategory.Pies, Weight = 2.3, FurColor = "white" },
        new Animal
        {
            Id = 3, Name = "Larry", AnimalCategory = AnimalCategory.Legwan, Weight = 35.5, FurColor = "mixed"
        },
        new Animal
        {
            Id = 4, Name = "Izzy", AnimalCategory = AnimalCategory.Szczur, Weight = 1.5, FurColor = "mixed grey"
        }
    ]; 
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(st => st.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        Animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        
        animal.Name = updatedAnimal.Name;
        animal.AnimalCategory = updatedAnimal.AnimalCategory;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;

        return NoContent();
    }

    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        Animals.Remove(animal);
        return NoContent();
    }
}
