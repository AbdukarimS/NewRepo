using Microsoft.AspNetCore.Mvc;
using CarWebApi.Models;

namespace CarWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private static List<Car> cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2022,
                Color = "Black",
                Price = 15000000
            },

            new Car
            {
                Id = 2,
                Brand = "BMW",
                Model = "X5",
                Year = 2023,
                Color = "White",
                Price = 35000000
            }
        };

        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            var car = cars.FirstOrDefault(x => x.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> Create(Car car)
        {
            car.Id = cars.Count > 0
                ? cars.Max(x => x.Id) + 1
                : 1;

            cars.Add(car);

            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id },
                car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Car updatedCar)
        {
            var car = cars.FirstOrDefault(x => x.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.Color = updatedCar.Color;
            car.Price = updatedCar.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = cars.FirstOrDefault(x => x.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            cars.Remove(car);

            return NoContent();
        }
    }
}