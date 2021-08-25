using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class UserInfoValidator : AbstractValidator<UserInfo>
    {
        public UserInfoValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.RegionId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Surname).NotEmpty();
            RuleFor(p => p.Phone).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            
        }
    }
}
