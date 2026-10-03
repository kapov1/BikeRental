class Rental
{
    public Guid CustomerId { get; }
    public Guid BikeId { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }
    public Guid Id { get; }

    public Rental(Guid customerId, Guid bikeId, DateOnly startDate, DateOnly plannedReturnDate, Guid id)
    {        
        BikeId = bikeId;
        CustomerId = customerId;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
        Id = id;
    }
}