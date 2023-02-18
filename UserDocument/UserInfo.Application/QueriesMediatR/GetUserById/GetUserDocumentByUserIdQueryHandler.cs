using Document.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Document.Application.Interfaces.Persistence;

namespace Document.Application.QueriesMediatR
{
    public class GetUserDocumentByUserIdQueryHandler : IRequestHandler<GetUserDocumentByUserIdQuery, UserDocumentDisplay>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDocumentByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDocumentDisplay> Handle(GetUserDocumentByUserIdQuery request, CancellationToken cancellationToken)
        {

            var User = _unitOfWork.UserDocumentRepository.GetAsQueryable(d => d.UserId == request.UserId).FirstOrDefault();
            if (User == null)
                return null;

            return _mapper.Map<UserDocumentDisplay>(User); ;
        }
    }
}
