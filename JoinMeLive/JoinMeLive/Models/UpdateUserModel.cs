namespace JoinMeLive.Models
{
    public class UpdateUserModel
    {
        public long UserId { get; set; }

        public string DisplayName { get; set; }

        public string PhotoUrl { get; set; }

        public string SelfSummary { get; set; }
    }
}
