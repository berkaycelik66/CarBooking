using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarDetailByIdWithBrandQuery
    {
        public int Id { get; set; }

        public GetCarDetailByIdWithBrandQuery(int id)
        {
            Id = id;
        }
    }
}
