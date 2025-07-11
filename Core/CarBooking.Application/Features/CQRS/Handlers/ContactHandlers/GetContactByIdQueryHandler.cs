﻿using CarBooking.Application.Features.CQRS.Queries.ContactQueries;
using CarBooking.Application.Features.CQRS.Results.ContactResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = value.ContactID,
                Name = value.Name,
                Mail = value.Mail,
                Subject = value.Subject,
                Content = value.Content,
                Date = value.Date,
            };
        }
    }
}
