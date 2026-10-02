class Rental
{
    public CustomerInfo CustomerInfo { get; }
    public BikeInfo BikeInfo { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }
    public Guid Id { get; } = Guid.NewGuid();

    public Rental(CustomerInfo customerInfo, BikeInfo bikeInfo, DateOnly startDate, DateOnly plannedReturnDate)
    {        
        BikeInfo = bikeInfo;
        CustomerInfo = customerInfo;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
    }
}