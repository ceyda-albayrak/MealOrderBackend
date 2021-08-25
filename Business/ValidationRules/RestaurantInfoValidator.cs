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
    public class RestaurantInfoValidator : AbstractValidator<RestaurantInfo>
    {
        public RestaurantInfoValidator()
        {
            RuleFor(p => p.Phone).NotEmpty();
            RuleFor(p => p.RegionId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.Address).Length(10, 100);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).Length(0,20);
        }
    }
}
