// Controller to expose endpoints for car management
[ApiController]  // Defines this as an API controller
[Route("api/[controller]")]  // Base route for all actions in this controller
public class CarsController : ControllerBase
{
    // Reference to the car service, which contains business logic
    private readonly ICarService _carService;

    // Constructor injection of the service to access car-related operations
    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    // Endpoint to add a car to a dealer's inventory
    // URL: POST api/cars/{dealerId}/add
    [HttpPost("{dealerId}/add")]
    public IActionResult AddCar(int dealerId, [FromBody] Car car)
    {
        _carService.AddCar(dealerId, car);  // Call the service method to add a car
        return Ok();  // Return a 200 OK response
    }

    // Endpoint to remove a car from the dealer's inventory by make and model
    // URL: DELETE api/cars/{dealerId}/remove?make=Audi&model=A4
    [HttpDelete("{dealerId}/remove")]
    public IActionResult RemoveCar(int dealerId, [FromQuery] string make, [FromQuery] string model)
    {
        _carService.RemoveCar(dealerId, make, model);  // Call the service method to remove the car
        return Ok();  // Return a 200 OK response
    }

    // Endpoint to list all cars for a specific dealer
    // URL: GET api/cars/{dealerId}/list
    [HttpGet("{dealerId}/list")]
    public IActionResult ListCars(int dealerId)
    {
        var cars = _carService.ListCars(dealerId);  // Call the service to get the car list
        return Ok(cars);  // Return the list of cars with a 200 OK status
    }

    // Endpoint to update the stock level of a car
    // URL: PUT api/cars/{dealerId}/update-stock?make=Audi&model=A4&stock=10
    [HttpPut("{dealerId}/update-stock")]
    public IActionResult UpdateStock(int dealerId, [FromQuery] string make, [FromQuery] string model, [FromQuery] int stock)
    {
        _carService.UpdateStock(dealerId, make, model, stock);  // Call the service to update stock
        return Ok();  // Return a 200 OK response
    }

    // Endpoint to search for a specific car by make and model
    // URL: GET api/cars/{dealerId}/search?make=Audi&model=A4
    [HttpGet("{dealerId}/search")]
    public IActionResult SearchCar(int dealerId, [FromQuery] string make, [FromQuery] string model)
    {
        var car = _carService.GetCar(dealerId, make, model);  // Call the service to get the car
        if (car == null) return NotFound();  // Return 404 if the car is not found
        return Ok(car);  // Return the car with a 200 OK status
    }
}