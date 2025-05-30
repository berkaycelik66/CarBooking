using CarBooking.Application.Features.Mediator.Queries.BlogQueries;
using CarBooking.Application.Features.Mediator.Results.AuthorResults;
using CarBooking.Application.Features.Mediator.Results.BlogResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogID = value.BlogID,
                Title = value.Title,
                AuthorID = value.AuthorID,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                CategoryID = value.CategoryID,
            };
        }
    }
}
