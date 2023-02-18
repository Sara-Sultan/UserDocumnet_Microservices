using UserInfo.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInfo.Application.Interfaces.Persistence;

namespace UserInfo.Application.QueriesMediatR
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDisplay>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDisplay> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var User = _unitOfWork.UserRepository.GetAsQueryable(u=>u.Id==request.Id)
                .Include(x=>x.Addresses).FirstOrDefault();
            if (User == null)
                return null;

            return _mapper.Map<UserDisplay>(User); ;
        }
    }
}
