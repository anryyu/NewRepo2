namespace WebApplication5.Models.DTO
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}