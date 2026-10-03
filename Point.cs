using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Point
{
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();

        #region ServiceContainer
            services.AddSingleton<BikeStorage>();
            services.AddSingleton<CustomerStorage>();
            services.AddSingleton<RentalStorage>();

            services.AddTransient<BikeService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<RentalService>();

            services.AddSingleton<PersistenceManager>();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(typeof(IDataStore<>), typeof(JsonDataStore<>));
        #endregion

        var serviceProvider = services.BuildServiceProvider();

        var bikeService = serviceProvider.GetRequiredService<BikeService>();
        var customerService = serviceProvider.GetRequiredService<CustomerService>();
        var rentalService = serviceProvider.GetRequiredService<RentalService>();

        var persistenceManager = serviceProvider.GetRequiredService<PersistenceManager>();

        persistenceManager.LoadData();

        var bikeId = bikeService.AddOrThrow("BMX", 20, Bike.BikeType.City);
        var customerId = customerService.Add("Max", "Var", "123", DateOnly.FromDateTime(DateTime.Now));
        var rentalId = rentalService.OpenOrThrow(bikeId, customerId, new DateOnly(2026, 10, 3), new DateOnly(2026, 10, 5));
        rentalService.CloseOrThrow(rentalId);

        persistenceManager.SaveData();
    }
}