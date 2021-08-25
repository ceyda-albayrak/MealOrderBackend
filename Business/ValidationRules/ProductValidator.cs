using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.LikePoint).LessThanOrEqualTo(5);
            RuleFor(p => p.LikePoint).GreaterThan(0);
            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.CategoryId).NotNull();
            RuleFor(p => p.RestaurantId).NotNull();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            
        }
    }
}
