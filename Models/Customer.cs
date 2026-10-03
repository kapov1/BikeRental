class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public DateOnly RegistrationDate { get; }
    public Guid Id { get; }

    public Customer(string firstName, string lastName, string phoneNumber, DateOnly registrationDate, Guid id)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        RegistrationDate = registrationDate;
        Id = id;
    }
}