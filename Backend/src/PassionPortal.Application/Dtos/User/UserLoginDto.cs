namespace Application.Dtos.User
{
    public record class UserLoginDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
