using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class OrderDetailValidator: AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(p => p.ProductId).NotNull();
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.Discount).NotEqual(100);
            RuleFor(p => p.Discount).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Quantity).GreaterThan(0);
            RuleFor(p => p.Quantity).NotEmpty();
         

        }
    }
}
