using Asphalt9CarRecords.Models; // Using the Models namespace
using Asphalt9CarRecords.Models.DTOs; // Using the DTOs namespace
using AutoMapper; // Using AutoMapper for object mapping
using Microsoft.EntityFrameworkCore; // Using Entity Framework Core

public interface ICarService // Defining the ICarService interface
{
    Task<IEnumerable<CarDto>> GetAllCarsAsync(); // Method to get all cars
    Task<CarDto?> GetCarByIdAsync(int id); // Method to get a car by ID
    Task<CarDto> AddCarAsync(CarDto carDto); // Method to add a new car
    Task<bool> UpdateCarAsync(int id, CarDto carDto); // Method to update an existing car
    Task<bool> DeleteCarAsync(int id); // Method to delete a car
}

public class CarService : ICarService // Implementing the ICarService interface
{
    private readonly CarContext _context; // CarContext for database operations
    private readonly IMapper _mapper; // AutoMapper for object mapping

    public CarService(CarContext context, IMapper mapper) // Constructor to inject dependencies
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync() // Method to get all cars
    {
        var cars = await _context.Cars.Include(c => c.CarClass).ToListAsync(); // Get all cars with their classes
        return _mapper.Map<IEnumerable<CarDto>>(cars); // Map cars to CarDto and return
    }

    public async Task<CarDto?> GetCarByIdAsync(int id) // Method to get a car by ID
    {
        var car = await _context.Cars.Include(c => c.CarClass).FirstOrDefaultAsync(c => c.Id == id); // Get car by ID with its class
        return car != null ? _mapper.Map<CarDto>(car) : null; // Map car to CarDto and return
    }

    public async Task<CarDto> AddCarAsync(CarDto carDto) // Method to add a new car
    {
        var car = _mapper.Map<Car>(carDto); // Map CarDto to Car
        _context.Cars.Add(car); // Add car to the context
        await _context.SaveChangesAsync(); // Save changes to the database
        return _mapper.Map<CarDto>(car); // Map car to CarDto and return
    }

    public async Task<bool> UpdateCarAsync(int id, CarDto carDto) // Method to update an existing car
    {
        var car = await _context.Cars.FindAsync(id); // Find the car by ID
        if (car == null)
        {
            return false; // Return false if car not found
        }

        _mapper.Map(carDto, car); // Map CarDto to the found car
        _context.Entry(car).State = EntityState.Modified; // Mark the car as modified
        await _context.SaveChangesAsync(); // Save changes to the database
        return true; // Return true if update successful
    }

    public async Task<bool> DeleteCarAsync(int id) // Method to delete a car
    {
        var car = await _context.Cars.FindAsync(id); // Find the car by ID
        if (car == null)
        {
            return false; // Return false if car not found
        }

        _context.Cars.Remove(car); // Remove the car from the context
        await _context.SaveChangesAsync(); // Save changes to the database
        return true; // Return true if deletion successful
    }
}
