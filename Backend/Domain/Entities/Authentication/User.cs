namespace Domain.Authentication;

public class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public required byte[] PasswordHash{ get; set; }
    public required byte[] PasswordSalt { get; set; }
}
