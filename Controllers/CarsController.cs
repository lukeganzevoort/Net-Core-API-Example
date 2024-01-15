using Microsoft.AspNetCore.Mvc;
using CarApi.Models;
using CarApi.Services;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetCars()
    {
        var cars = _carService.GetAllCars();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCar(int id)
    {
        var car = _carService.GetCarById(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> CreateCar(Car car)
    {
        _carService.AddCar(car);
        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCar(int id, Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        var existingCar = _carService.GetCarById(id);
        if (existingCar == null)
        {
            return NotFound();
        }

        _carService.UpdateCar(car);
        return NoContent();
    }
}




