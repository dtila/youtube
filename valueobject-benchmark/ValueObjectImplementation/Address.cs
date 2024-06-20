namespace ValueObjectImplementation;

public class AddressValueObject : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string ZipCode { get; }

    public AddressValueObject(string street, string city, string state, string country, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}


public class GpsLocatedAddress : AddressValueObject
{
    public float Latitude { get; }
    public float Longitude { get; }

    public GpsLocatedAddress(string street, string city, string state, string country, string zipCode, float latitude, float longitude) : base(street, city, state, country, zipCode)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        foreach (var value in base.GetAtomicValues())
            yield return value;
        yield return Latitude;
        yield return Longitude;
    }
}



public sealed record AddressRecord 
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string ZipCode { get; }

    public AddressRecord(string street, string city, string state, string country, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
}
