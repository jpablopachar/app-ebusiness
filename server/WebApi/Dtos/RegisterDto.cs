namespace WebApi.Dtos
{
    public class RegisterDto
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
    }
}