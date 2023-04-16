namespace Iran.Sms.Core;

public record SmsChannelData
{
    public string Key { get; }
    
    public object Value { get; }
    
    public SmsChannelData(string key, object value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException("key cannot be null or empty.", nameof(key));

        if (value is null)
            throw new ArgumentNullException("value cannot be null.", nameof(value));
        
        Key = key;
        Value = value;
    }

    public static SmsChannelData Create(string key, object value)
    {
        return new SmsChannelData(key, value);
    }

    public TValue GetValue<TValue>() => (TValue)Value;

    public override string ToString()
    {
        return $"[Key]: {Key} {Environment.NewLine} [Value]: {Value}";
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = 8234992;
            return hashCode * 1451 + EqualityComparer<string>.Default.GetHashCode(Key);
        }
    }
}