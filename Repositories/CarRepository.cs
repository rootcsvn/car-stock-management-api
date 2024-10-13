// Implementation of the ICarRepository interface to manage car data using in-memory storage
public class CarRepository : ICarRepository
{
    // In-memory data structure to store dealers and their car inventories
    // Each dealer is identified by a unique DealerId
    private readonly Dictionary<int, Dealer> _dealerData;

    // Constructor initializing the in-memory data structure (simulating a database)
    public CarRepository()
    {
        _dealerData = new Dictionary<int, Dealer>();
    }

    // Adds a car to a dealer's inventory
    public void AddCar(int dealerId, Car car)
    {
        // If the dealer does not exist in the data structure, create a new dealer
        if (!_dealerData.ContainsKey(dealerId))
            _dealerData[dealerId] = new Dealer { DealerId = dealerId };

        // Add the car to the dealer's inventory
        _dealerData[dealerId].Cars.Add(car);
    }

    // Removes a car from the dealer's inventory by make and model
    public void RemoveCar(int dealerId, string make, string model)
    {
        // Check if the dealer exists
        if (_dealerData.ContainsKey(dealerId))
        {
            // Find the car in the dealer's inventory by make and model
            var car = _dealerData[dealerId].Cars.FirstOrDefault(c => c.Make == make && c.Model == model);

            // If the car exists, remove it from the inventory
            if (car != null) _dealerData[dealerId].Cars.Remove(car);
        }
    }

    // Returns a list of all cars in a dealer's inventory
    public List<Car> ListCars(int dealerId)
    {
        // Return the list of cars if the dealer exists, otherwise return an empty list
        return _dealerData.ContainsKey(dealerId) ? _dealerData[dealerId].Cars : new List<Car>();
    }

    // Fetches a car by make and model for a specific dealer
    public Car GetCar(int dealerId, string make, string model)
    {
        // Find the car in the dealer's inventory by make and model, or return null if not found
        return _dealerData.ContainsKey(dealerId)
            ? _dealerData[dealerId].Cars.FirstOrDefault(c => c.Make == make && c.Model == model)
            : null;
    }

    // Updates the stock quantity of a car in a dealer's inventory
    public void UpdateStock(int dealerId, string make, string model, int stock)
    {
        // Find the car and update its stock if it exists
        var car = GetCar(dealerId, make, model);
        if (car != null) car.Stock = stock;
    }
}