using Microsoft.Extensions.Logging;

class CustomerService
{
    private readonly CustomerStorage _customerStorage;
    private readonly ILogger<CustomerService> _logger;

    public CustomerService(CustomerStorage customerStorage, ILogger<CustomerService> logger)
    {
        _customerStorage = customerStorage;
        _logger = logger;
    }

    private void AddToData(Customer customer)
    {
        _customerStorage.Add(customer);
        _logger.LogInformation("Customer added to storage\nCustomer: {Id}", customer.Id);
    }

    public Guid Add(string firstName, string lastName, string phoneNumber, DateOnly registrationDate)
    {
        Customer customer = new(firstName, lastName, phoneNumber, registrationDate, Guid.NewGuid());

        AddToData(customer);
        _logger.LogInformation("Customer registered\nCustomer: {Id}", customer.Id);

        return customer.Id;
    }

    public List<CustomerInfo> Find(Func<Customer, bool> match)
    {
        return _customerStorage.Customers
            .Where(match)
            .Select(client => new CustomerInfo(
                client.FirstName,
                client.LastName,
                client.PhoneNumber,
                client.RegistrationDate
            ))
            .ToList();
    }
}