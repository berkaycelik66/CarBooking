﻿using CarBooking.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBooking.Application.Features.Mediator.Results.FooterAddressResults;
using CarBooking.Application.Interfaces;
using CarBooking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressID = x.FooterAddressID,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Mail = x.Mail,
            }).ToList();
        }
    }
}
