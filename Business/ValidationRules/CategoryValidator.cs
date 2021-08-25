using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).NotNull();
           
        }
    }
}
