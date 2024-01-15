using System.Collections.Generic;
using CarApi.Models;

namespace CarApi.Services {
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
    }
}
