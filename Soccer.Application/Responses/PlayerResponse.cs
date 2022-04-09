namespace Soccer.Application.Responses
{
    public class PlayerResponse
    {
        public long PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? TeamName { get; set; }
    }
}
