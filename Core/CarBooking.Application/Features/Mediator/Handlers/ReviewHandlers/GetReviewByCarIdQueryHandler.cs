using CarBooking.Application.Features.Mediator.Queries.ReviewQueries;
using CarBooking.Application.Features.Mediator.Results.ReviewResults;
using CarBooking.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _reviewRepository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                ReviewID = x.ReviewID,
                CustomerName = x.CustomerName,
                Comment = x.Comment,
                RatingValue = x.RatingValue,
                ReviewDate = x.ReviewDate,
                CarID = x.CarID
            }).ToList();
        }
    }
}
