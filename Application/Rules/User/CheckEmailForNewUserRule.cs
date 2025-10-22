using Application.Repositories;
using Core.Utilities.ServiceTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rules
{
    public class CheckEmailForNewUserRule : IBusinessRule
    {
        readonly IUserRepository _userRepository;
        readonly string Email;
        public CheckEmailForNewUserRule(string email)
        {
            _userRepository = StaticServiceProvider.GetService<IUserRepository>();
            Email = email;
        }
        public async Task<BusinessRuleResult> InvokeAsync()
        {
            var isAvaible = await _userRepository.IsExistAsync(exs=> exs.Email == Email);

            return isAvaible ? new BusinessRuleResult(false, "Email is already taken.")
                             : new BusinessRuleResult(true);

        }
    }
}
