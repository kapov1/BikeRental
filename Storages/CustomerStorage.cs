class CustomerStorage
{
    private readonly List<Customer> _customers = new();

    public IReadOnlyList<Customer> Customers => _customers;

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }
}