class Rental
{
    public Customer Customer { get; }
    public BikeInfo BikeInfo { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }
    public Guid Id { get; } = Guid.NewGuid();

    public Rental(Customer customer, BikeInfo bikeInfo, DateOnly startDate, DateOnly plannedReturnDate)
    {        
        BikeInfo = bikeInfo;
        Customer = customer;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
    }
}