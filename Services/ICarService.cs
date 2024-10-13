// Interface defining business logic for car management
public interface ICarService
{
    // Adds a car to the dealer's inventory
    void AddCar(int dealerId, Car car);

    // Removes a car from the dealer's inventory by make and model
    void RemoveCar(int dealerId, string make, string model);

    // Lists all cars for a specific dealer
    List<Car> ListCars(int dealerId);

    // Retrieves a specific car by make and model for a dealer
    Car GetCar(int dealerId, string make, string model);

    // Updates the stock level of a car in the dealer's inventory
    void UpdateStock(int dealerId, string make, string model, int stock);
}