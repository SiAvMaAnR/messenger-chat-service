namespace Messenger.Domain.ValueObjects;

public abstract class BaseValueObject
{
    public static bool operator ==(BaseValueObject? a, BaseValueObject? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(BaseValueObject? a, BaseValueObject? b) => !(a == b);

    public virtual bool Equals(BaseValueObject? other) =>
        other is not null && ValuesAreEqual(other);

    public override bool Equals(object? obj) =>
        obj is BaseValueObject valueObject && ValuesAreEqual(valueObject);

    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(
                default(int),
                (hashCode, value) => HashCode.Combine(hashCode, value.GetHashCode())
            );

    protected abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(BaseValueObject valueObject) =>
        GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
}
