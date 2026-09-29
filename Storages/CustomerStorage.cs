class CustomerStorage
{
    private readonly List<Customer> _customers = new();

    public IReadOnlyList<Customer> Customers => _customers;

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public List<Customer> FindAll(Predicate<Customer> match)
    {
        return _customers.FindAll(match);
    }
}