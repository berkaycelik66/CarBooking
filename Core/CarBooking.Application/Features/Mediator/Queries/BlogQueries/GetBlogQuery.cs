﻿using CarBooking.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogQuery: IRequest<List<GetBlogQueryResult>>
    {
    }
}
