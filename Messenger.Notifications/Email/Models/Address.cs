namespace MessengerX.Notifications.Email.Models;

public class Address
{
    public string? Name { get; set; }
    public string Email { get; set; } = null!;

    public Address(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
