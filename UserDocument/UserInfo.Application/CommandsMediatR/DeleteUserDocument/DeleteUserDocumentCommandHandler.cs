using Document.Application.Events;
using Document.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Document.Application.Interfaces.Persistence;

namespace Document.Application.CommandsMediatR
{
    public class DeleteUserDocumentCommandHandler : IRequestHandler<DeleteUserDocumentCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserDocumentCommandHandler(IUnitOfWork unitOfWork
            , IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteUserDocumentCommand request, CancellationToken cancellationToken)
        {
            var UserDocument = _unitOfWork.UserDocumentRepository.GetAsQueryable(d=>d.UserId==request.UserId).FirstOrDefault();
            if (UserDocument == null)
                throw new NotFoundException(nameof(UserDocument), request.UserId);

            _unitOfWork.UserDocumentRepository.Remove(UserDocument);
            
            _unitOfWork.Save();

            //notification
            await _mediator.Publish(new UserDeleted(UserDocument));

            return Unit.Value;
        }

    }
}
