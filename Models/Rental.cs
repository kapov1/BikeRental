using System.Text.Json.Serialization;

class Rental
{
    public enum RentalStatus
    {
        Active,
        Completed
    }

    public Guid CustomerId { get; }
    public Guid BikeId { get; }
    public DateOnly StartDate { get; }
    public DateOnly PlannedReturnDate { get; }
    public Guid Id { get; }
    public RentalStatus Status { get; private set; } = RentalStatus.Active;

    [JsonConstructor]
    private Rental(Guid customerId, Guid bikeId, DateOnly startDate, DateOnly plannedReturnDate, Guid id, RentalStatus status)
    {
        BikeId = bikeId;
        CustomerId = customerId;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
        Id = id;
        Status = status;
    }

    public Rental(Guid customerId, Guid bikeId, DateOnly startDate, DateOnly plannedReturnDate, Guid id)
    {
        BikeId = bikeId;
        CustomerId = customerId;
        StartDate = startDate;
        PlannedReturnDate = plannedReturnDate;
        Id = id;
    }

    public void ChangeStatusToActive() => Status = RentalStatus.Active;
    public void ChangeStatusToCompleted() => Status = RentalStatus.Completed;
}