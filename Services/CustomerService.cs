class CustomerService
{
    private readonly CustomerStorage _customerStorage;

    public CustomerService(CustomerStorage customerStorage)
    {
        _customerStorage = customerStorage;
    }

    public bool Contains(Customer customer)
    {
        return _customerStorage.Customers.Any(client => client.PhoneNumber == customer.PhoneNumber);
    }

    public bool TryAdd(Customer customer)
    {
        if (!Contains(customer))
        {
            _customerStorage.Add(customer);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Customer> Find(Func<Customer, bool> match)
    {
        return _customerStorage.Customers.Where(match).ToList();
    }
}