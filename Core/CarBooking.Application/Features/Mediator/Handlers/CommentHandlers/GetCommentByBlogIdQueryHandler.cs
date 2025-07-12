using CarBooking.Application.Features.Mediator.Queries.CommentQueries;
using CarBooking.Application.Features.Mediator.Results.CommentResults;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _commentRepository.GetCommentsByBlogId(request.Id);
            return values.Select(x => new GetCommentByBlogIdQueryResult
            {
                CommentID = x.CommentID,
                Name = x.Name,
                Mail = x.Mail,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                BlogID = x.BlogID
            }).ToList();
        }
    }
}
