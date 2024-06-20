namespace ValueObjectImplementation;

public sealed class AddressValueNumberObject : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public int ZipCode { get; }

    public AddressValueNumberObject(string street, string city, string state, string country, int zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street.ToLowerInvariant();
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}



public sealed record AddressRecordNumber
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public int ZipCode { get; }

    public AddressRecordNumber(string street, string city, string state, string country, int zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
}
