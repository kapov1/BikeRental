class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public string RegistrationDate { get; }

    public Customer(string firstName, string lastName, string phoneNumber, string registrationDate)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        RegistrationDate = registrationDate;
    }
}