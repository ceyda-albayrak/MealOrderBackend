using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.City).NotNull();
            RuleFor(p => p.City).Length(2, 20);
        }
    }
}
