using CarBooking.Application.Features.Mediator.Queries.CommentQueries;
using CarBooking.Application.Features.Mediator.Results.CommentResults;
using CarBooking.Application.Features.Mediator.Results.FeatureResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                CommentID = values.CommentID,
                Name = values.Name,
                Mail = values.Mail,
                Content = values.Content,
                CreatedDate = values.CreatedDate,
                BlogID = values.BlogID,
            };
        }
    }
}
