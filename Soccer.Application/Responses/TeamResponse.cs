namespace Soccer.Application.Responses
{
    public class TeamResponse
    {
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string ManagerEmail { get; set; }
        public List<PlayerResponse> Players { get; set; }
    }
}
