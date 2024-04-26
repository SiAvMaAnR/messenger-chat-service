using Messenger.Domain.ValueObjects;

public sealed class Address : BaseValueObject
{
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}
