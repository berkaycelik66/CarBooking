﻿using CarBooking.Application.Features.Mediator.Queries.AuthorQueries;
using CarBooking.Application.Features.Mediator.Results.AuthorResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorID = value.AuthorID,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
