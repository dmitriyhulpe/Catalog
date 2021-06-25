using Catalog.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Validation
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator()
        {
            RuleFor(category => category.CategoryID)
            .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(category => category.CategoryName)
            .NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
