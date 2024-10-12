// Interface to define the operations for managing car data
public interface ICarRepository
{
    // Adds a car to the dealer's inventory
    void AddCar(int dealerId, Car car);

    // Removes a car from the dealer's inventory based on make and model
    void RemoveCar(int dealerId, string make, string model);

    // Returns the list of cars for a specific dealer
    List<Car> ListCars(int dealerId);

    // Fetches a specific car from the dealer's inventory by make and model
    Car GetCar(int dealerId, string make, string model);

    // Updates the stock quantity of a car in the dealer's inventory
    void UpdateStock(int dealerId, string make, string model, int stock);
}