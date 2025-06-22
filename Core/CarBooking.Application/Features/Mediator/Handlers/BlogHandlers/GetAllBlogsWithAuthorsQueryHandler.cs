using CarBooking.Application.Features.Mediator.Queries.BlogQueries;
using CarBooking.Application.Features.Mediator.Results.BlogResults;
using CarBooking.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorsQuery, List<GetAllBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorsQueryResult
            {
                BlogID = x.BlogID,
                Title = x.Title,
                Description = x.Description,
                AuthorID = x.AuthorID,
                AuthorName = x.Author!.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                CategoryID = x.CategoryID,
                CategoryName = x.Category!.Name,
            }).ToList();
        }
    }
}
