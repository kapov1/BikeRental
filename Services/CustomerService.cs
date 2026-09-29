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
            _customerStorage.Customers.Add(customer);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryDelete(Customer customer)
    {
        if (Contains(customer))
        {
            _customerStorage.Customers.Remove(customer);
            return true;
        }
        else return false;
    }

    public List<Customer> Find(Predicate<Customer> match)
    {
        return _customerStorage.Customers.FindAll(match);
    }
}