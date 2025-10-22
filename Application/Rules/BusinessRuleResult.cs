namespace Application.Rules
{
    public class BusinessRuleResult
    {
        public bool Success { get; }
        public string? Message { get; }

        public BusinessRuleResult(bool succcess)
        {
            Success = succcess;
        }
        public BusinessRuleResult(bool succcess, string message) : this(succcess)
        {
            Message = message;
        }
    }
}
