class CustomerService
{
    private readonly CustomerStorage _customerStorage;

    public CustomerService(CustomerStorage customerStorage)
    {
        _customerStorage = customerStorage;
    }

    private void AddToData(Customer customer) => _customerStorage.Add(customer);

    public Guid Add(string firstName, string lastName, string phoneNumber, DateOnly registrationDate)
    {
        Customer customer = new(firstName, lastName, phoneNumber, registrationDate, Guid.NewGuid());

        AddToData(customer);

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