namespace Application.Models.Rest.User
{
    public class SetUserClaimsRequest
    {
        public Guid UserId { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
