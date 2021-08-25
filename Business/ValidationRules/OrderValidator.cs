using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.RequiredDate).GreaterThan(0);
            RuleFor(p => p.Statu).NotNull();
            RuleFor(p => p.Statu).NotEmpty();
            RuleFor(p => p.UserId).NotNull();
        }
    }
}
