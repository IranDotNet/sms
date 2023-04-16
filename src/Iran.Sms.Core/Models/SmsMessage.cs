namespace Iran.Sms.Core;

public class SmsMessage
{
    
    public string Body { get; private set; }
    
    public PhoneNumber From { get; private set; }
    
    public PhoneNumber To { get; private set; }
    
    
}