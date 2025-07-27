using CarBooking.Application.Features.Mediator.Commands.ReviewCommands;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewID);
            if (value != null)
            {
                value.CustomerName = request.CustomerName;
                value.Comment = request.Comment;
                value.RatingValue = request.RatingValue;
                value.CarID = request.CarID;
                await _repository.UpdateAsync(value);
            }
        }
    }
}
