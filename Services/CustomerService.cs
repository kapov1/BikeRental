class CustomerService
{
    private readonly CustomerStorage _customerStorage;

    public CustomerService(CustomerStorage customerStorage)
    {
        _customerStorage = customerStorage;
    }

    private bool Contains(Customer customer)
    {
        return _customerStorage.Customers.Any(client => client.PhoneNumber == customer.PhoneNumber);
    }

    private bool AddToData(Customer customer)
    {
        if (Contains(customer))
        {
            return false;
        }

        _customerStorage.Add(customer);
        return true;
    }

    public bool TryAdd(string firstName, string lastName, string phoneNumber, DateOnly registrationDate)
    {
        Customer customer = new(firstName, lastName, phoneNumber, registrationDate);

        if (!AddToData(customer)) return false;

        return true;
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

readonly record struct CustomerInfo(
    string FirstName,
    string LastName,
    string PhoneNumber,
    DateOnly RegestrationDate
);