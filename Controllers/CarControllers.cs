using Asphalt9CarRecords.Models.DTOs; // Using the DTOs namespace
using Asphalt9CarRecords.Models; // Using the Services namespace
using Microsoft.AspNetCore.Mvc; // Using ASP.NET Core MVC

namespace Asphalt9CarRecords.Controllers
{
    [Route("api/[controller]")] // Route for the controller
    [ApiController] // Marking the class as an API controller
    public class CarsController : ControllerBase // Inheriting from ControllerBase
    {
        private readonly ICarService _carService; // CarService for handling car operations

        public CarsController(ICarService carService) // Constructor to inject dependencies
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet] // HTTP GET method
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars() // Get all cars
        {
            var cars = await _carService.GetAllCarsAsync(); // Get all cars from the service
            return Ok(cars); // Return OK with the list of cars
        }

        // GET: api/Cars/5
        [HttpGet("{id}")] // HTTP GET method with ID
        public async Task<ActionResult<CarDto>> GetCar(int id) // Get car by ID
        {
            var car = await _carService.GetCarByIdAsync(id); // Get the car from the service
            if (car == null)
            {
                return NotFound(); // Return NotFound if car not found
            }

            return Ok(car); // Return OK with the car
        }

        // POST: api/Cars
        [HttpPost] // HTTP POST method
        public async Task<ActionResult<CarDto>> PostCar(CarDto carDto) // Add a new car
        {
            var car = await _carService.AddCarAsync(carDto); // Add the car using the service
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car); // Return CreatedAtAction with the new car
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")] // HTTP PUT method with ID
        public async Task<IActionResult> PutCar(int id, CarDto carDto) // Update an existing car
        {
            if (id != carDto.Id)
            {
                return BadRequest(); // Return BadRequest if ID doesn't match
            }

            var success = await _carService.UpdateCarAsync(id, carDto); // Update the car using the service
            if (!success)
            {
                return NotFound(); // Return NotFound if update unsuccessful
            }

            return NoContent(); // Return NoContent if update successful
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")] // HTTP DELETE method with ID
        public async Task<IActionResult> DeleteCar(int id) // Delete a car
        {
            var success = await _carService.DeleteCarAsync(id); // Delete the car using the service
            if (!success)
            {
                return NotFound(); // Return NotFound if deletion unsuccessful
            }

            return NoContent(); // Return NoContent if deletion successful
        }
    }
}
