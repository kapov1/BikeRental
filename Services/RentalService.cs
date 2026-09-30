class RentalService
{
    private readonly RentalStorage _rentalStorage;

    public RentalService(RentalStorage rentalStorage)
    {
        _rentalStorage = rentalStorage;
    }
}