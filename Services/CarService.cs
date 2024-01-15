using System.Collections.Generic;
using System.Linq;
using CarApi.Models;
using CarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Services {
    public class CarService : ICarService
    {
        private readonly CarContext _context;

        public CarService(CarContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            var existingCar = _context.Cars.Find(car.Id);
            if (existingCar != null)
            {
                // Map the updated fields to the existing car
                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Color = car.Color;
                existingCar.Price = car.Price;

                _context.SaveChanges();
            }
        }
    }
}