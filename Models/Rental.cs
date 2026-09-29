class Rental
{
    public Customer Customer { get; }
    public Bike Bike { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }

    public Rental(Customer customer, Bike bike, DateOnly startDate, DateOnly plannedReturnDate, BikeService bikeService)
    {        
        if (bikeService.TryRent(bike)) 
        {
            Bike = bike;
        }
        else throw new ArgumentException($"Bike {bike.BikeID} is currently unavailable: it is either already rented out or undergoing maintenance.");

        Customer = customer;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
    }
}