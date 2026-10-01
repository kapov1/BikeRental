class Rental
{
    public Customer Customer { get; }
    public Bike Bike { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }
    public Guid Id { get; } = Guid.NewGuid();

    public Rental(Customer customer, Bike bike, DateOnly startDate, DateOnly plannedReturnDate)
    {        
        Bike = bike;
        Customer = customer;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
    }
}