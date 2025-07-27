using CarBooking.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri adı boş geçilemez!")
                .MinimumLength(5).WithMessage("Müşteri adı en az 5 karakterden oluşmalıdır!");
            RuleFor(x => x.RatingValue).InclusiveBetween(1, 5).WithMessage("Değer 1 ile 5 arasında olmalıdır!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş geçilemez!").MinimumLength(50).WithMessage("Yorum en az 20 karakterden oluşmalıdır!").MaximumLength(500).WithMessage("Maksimum 500 karakterlik yorum girişi yapılabilir!");
        }
    }
}
