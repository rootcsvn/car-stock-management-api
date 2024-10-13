// Implementation of the ICarService interface, providing business logic for managing cars
public class CarService : ICarService
{
    // Reference to the car repository to handle data operations
    private readonly ICarRepository _carRepository;

    // Constructor injection of the repository to access data operations
    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    // Calls the repository method to add a car to a dealer's inventory
    public void AddCar(int dealerId, Car car) => _carRepository.AddCar(dealerId, car);

    // Calls the repository method to remove a car from a dealer's inventory
    public void RemoveCar(int dealerId, string make, string model) => _carRepository.RemoveCar(dealerId, make, model);

    // Retrieves a list of cars for a dealer by calling the repository
    public List<Car> ListCars(int dealerId) => _carRepository.ListCars(dealerId);

    // Retrieves a specific car by make and model using the repository
    public Car GetCar(int dealerId, string make, string model) => _carRepository.GetCar(dealerId, make, model);

    // Updates the stock level of a specific car in the dealer's inventory
    public void UpdateStock(int dealerId, string make, string model, int stock) => _carRepository.UpdateStock(dealerId, make, model, stock);
}