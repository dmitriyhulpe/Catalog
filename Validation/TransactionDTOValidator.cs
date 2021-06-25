using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DTO;

namespace Catalog.Validation
{
    public class TransactionDTOValidator : AbstractValidator<TransactionDTO>
    {
        public TransactionDTOValidator()
        {
            RuleFor(transaction => transaction.TransactionID)
            .NotEmpty().WithMessage("Name cannot be empty");

            RuleFor(transaction => transaction.Quantity)
            .NotEmpty().WithMessage("Quantity cannot be empty");

            RuleFor(transaction => transaction.Date)
            .NotNull()
            .NotEmpty().WithMessage("Date cannot be empty");

            RuleFor(transaction => transaction.TotalPrice)
            .NotEmpty().WithMessage("Price cannot be null");
        }
    }
}
