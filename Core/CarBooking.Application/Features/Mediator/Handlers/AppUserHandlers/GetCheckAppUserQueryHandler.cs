using CarBooking.Application.Features.Mediator.Queries.AppUserQueries;
using CarBooking.Application.Features.Mediator.Results.AppUserResults;
using CarBooking.Application.Interfaces.AppRoleInterfaces;
using CarBooking.Application.Interfaces.AppUserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var value = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                value.IsExist  = false;
            }
            else
            {
                var role = await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID);
                value.IsExist = true;
                value.Id = user.AppUserID;
                value.Username = user.Username;
                value.Role = role.Name;
            }

            return value;
        }
    }
}
