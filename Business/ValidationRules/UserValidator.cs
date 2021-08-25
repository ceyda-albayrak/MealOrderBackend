using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).Length(8, 16);
        }
    }
}
