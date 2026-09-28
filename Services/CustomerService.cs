class CustomerService
{
    private CustomerStorage _customerStorage;

    public CustomerService(CustomerStorage customerStorage)
    {
        _customerStorage = customerStorage;
    }
}