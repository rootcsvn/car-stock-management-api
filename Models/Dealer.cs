public class Dealer
{
    // Unique identifier for each dealer
    public int DealerId { get; set; }

    // List to hold the inventory of cars for each dealer
    public List<Car> Cars { get; set; }

    // Constructor initializing the car list to prevent null reference issues
    public Dealer()
    {
        Cars = new List<Car>();
    }
}