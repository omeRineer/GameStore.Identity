using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rules
{
    public static class BusinessRuleEngine
    {
        public static async Task<BusinessRuleResult> Run(params IBusinessRule[] rules)
        {
            foreach (var rule in rules)
            {
                var result = await rule.InvokeAsync();
                if (!result.Success)
                    return result;
            }

            return new BusinessRuleResult(true);
        }
    }
}
