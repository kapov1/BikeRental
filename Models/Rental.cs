class Rental
{
    public Customer Customer { get; }
    public Bike Bike { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }

    public Rental(Customer customer, Bike bike, DateOnly startDate, DateOnly plannedReturnDate)
    {
        Customer = customer;

        if (bike.Status == Bike.BikeStatus.Available) 
        {
            Bike = bike;
            Bike.Status = Bike.BikeStatus.Rented;
        }
        else throw new ArgumentException($"Bike {bike.BikeID} is currently unavailable: it is either already rented out or undergoing maintenance.");

        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
    }
}