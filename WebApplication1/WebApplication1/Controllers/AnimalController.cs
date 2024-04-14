using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal{IdAnimal = 1, Name = "Jimmy", Category = "Dog", Weight = 32.5, FurColor = "Black"},
        new Animal{IdAnimal = 2, Name = "Luna", Category = "Cat", Weight = 4.2, FurColor = "White"},
        new Animal{IdAnimal = 3, Name = "John", Category = "Rabbit", Weight = 6.7, FurColor = "Gray"}

    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.IdAnimal == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(animal => animal.IdAnimal == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToRemove = _animals.FirstOrDefault(animal => animal.IdAnimal == id);

        if (animalToRemove == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToRemove);
        return NoContent();
    }
}