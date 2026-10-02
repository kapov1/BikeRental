using Microsoft.Extensions.Configuration;

class RentalService
{
    private readonly RentalStorage _rentalStorage;
    private readonly BikeService _bikeService;
    private readonly int _penaltyRatePerDay;

    public RentalService(RentalStorage rentalStorage, BikeService bikeService, IConfiguration configuration)
    {
        _rentalStorage = rentalStorage;
        _bikeService = bikeService;
        _penaltyRatePerDay = configuration.GetValue<int>("PenaltyRatePerDay");
    }

    private void AddToData(Rental rental) => _rentalStorage.Add(rental);

    private bool ValidDataForRental(Guid bikeId, DateOnly startDate, DateOnly plannedReturnDate)
    {
        var bikeStatus = _bikeService.GetRequiredBikeStatus(bikeId);
        var bikeInfo = _bikeService.GetRequiredBikeInfo(bikeId);

        if (startDate > plannedReturnDate)
        {
            Console.WriteLine("Return date must be after start date.");
            return false;
        }
        if (bikeStatus != Bike.BikeStatus.Available)
        {
            Console.WriteLine($"Bike {bikeInfo.BikeName} is currently unavailable: it is either already rented out or undergoing maintenance.");
            return false;
        }

        return true;
    }

    private Rental GetRentalOrThrow(Guid key)
    {
        var rental = _rentalStorage.Rentals.FirstOrDefault(rent => rent.Id == key);

        return rental ?? throw new KeyNotFoundException("Rental with the specified key was not found.");
    }

    public Guid OpenOrThrow(Guid bikeId, CustomerInfo customerInfo, DateOnly startDate, DateOnly plannedReturnDate)
    {   
        var bikeInfo = _bikeService.GetRequiredBikeInfo(bikeId);

        if (!ValidDataForRental(bikeInfo.Id, startDate, plannedReturnDate))
        {
            throw new ArgumentException("Rental validation failed. Cannot process the request.");
        }
        if (!_bikeService.TryRent(bikeInfo.Id))
        {
            throw new ArgumentException("Selected bike is not available for rental.");
        }

        Rental rental = new(customerInfo, bikeInfo, startDate, plannedReturnDate);
        AddToData(rental);
        return rental.Id;
    }

    public (int rentalCost, int penaltyFee) CalculateRental(Guid key)
    {
        var rental = GetRentalOrThrow(key);

        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        DateOnly startDate = rental.StartDate;
        DateOnly plannedReturnDate = rental.PlannedReturnDate;
        int currentRentalDays = currentDate.DayNumber - startDate.DayNumber;
        int totalRentalDays = plannedReturnDate.DayNumber - startDate.DayNumber;
        int price = rental.BikeInfo.PricePerDay;

        int rentalCost = plannedReturnDate >= currentDate ? currentRentalDays * price : totalRentalDays * price;
        int penaltyFee = plannedReturnDate >= currentDate ? 0 : (currentDate.DayNumber - plannedReturnDate.DayNumber) * _penaltyRatePerDay;
            
        return (rentalCost, penaltyFee);
    }   

    public void CloseOrThrow(Guid key)
    {
        var rental = GetRentalOrThrow(key);

        if (!_bikeService.TryReturn(rental.BikeInfo.Id)) throw new InvalidOperationException("Cannot return a bike that is not currently rented.");

        //типо сохраняю в историю, в файлы, логи вывожу...
    }
}