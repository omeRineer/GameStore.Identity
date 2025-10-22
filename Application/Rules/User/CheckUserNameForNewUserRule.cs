using Application.Repositories;
using Core.Utilities.ServiceTools;

namespace Application.Rules
{
    public class CheckUserNameForNewUserRule : IBusinessRule
    {
        readonly IUserRepository _userRepository;
        readonly string UserName;
        public CheckUserNameForNewUserRule(string userName)
        {
            _userRepository = StaticServiceProvider.GetService<IUserRepository>();
            UserName = userName;
        }
        public async Task<BusinessRuleResult> InvokeAsync()
        {
            var isAvaible = await _userRepository.IsExistAsync(exs => exs.UserName == UserName);

            return isAvaible ? new BusinessRuleResult(false, "UserName is already taken.")
                             : new BusinessRuleResult(true);

        }
    }
}
