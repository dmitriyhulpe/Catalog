using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DTO;

namespace Catalog.Validation
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(product => product.ProductID)
            .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(product => product.CategoryID)
            .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Description cannot be empty");

            RuleFor(product => product.Price)
            .NotEmpty().WithMessage("Price cannot be null");
        }
    }
}
