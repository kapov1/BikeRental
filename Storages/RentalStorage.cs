class RentalStorage
{
    private readonly List<Rental> _rentals = new();

    public IReadOnlyList<Rental> Rentals => _rentals;

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
    }
}