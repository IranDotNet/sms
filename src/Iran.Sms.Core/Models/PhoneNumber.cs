namespace Iran.Sms.Core;


public sealed class PhoneNumber : IEquatable<PhoneNumber>, IEquatable<string>
{
    private readonly string _number;

    public PhoneNumber(string number)
    {
        //TODO : replace with IsNullOrEmpty in Iran.Core library
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentNullException($"The PhoneNumber you try to create is empty or null.", nameof(number));
        
        _number = number;
    }
    
    public static implicit operator string (PhoneNumber phoneNumber)
        => phoneNumber.ToString();

    public static implicit operator PhoneNumber(string number)
        => new PhoneNumber(number);
    
    public static bool operator ==(PhoneNumber left, PhoneNumber right)
        => EqualityComparer<PhoneNumber>.Default.Equals(left, right);

    public static bool operator !=(PhoneNumber left, PhoneNumber right) => !(left == right);

    public bool Equals(PhoneNumber? other)
    {
        return other is not null && other.ToString().Equals(_number, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is string stringValue) Equals(stringValue);
        if (obj is PhoneNumber number) Equals(number);
        return false;
    }

    public bool Equals(string? other)
    {
        return other is not null && other.Equals(_number, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return _number;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = 8234992;
            return hashCode * 1451 + EqualityComparer<string>.Default.GetHashCode(_number);
        }
    }
}