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
using Document.Domain.Entities;
using FluentValidation.Results;

namespace Document.Application.CommandsMediatR
{
    public class AddNewUserDocumentCommandHandler : IRequestHandler<AddNewUserDocumentCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddNewUserDocumentCommandHandler(IUnitOfWork unitOfWork
            , IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AddNewUserDocumentCommand request, CancellationToken cancellationToken)
        {
            //validation
            var validator = new AddNewUserDocumentCommandValidator();
            ValidationResult results = validator.Validate(request);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
                //validator.ValidateAndThrow(request);
            }

            //map
            var entity = _mapper.Map<UserDocument>(request);

            _unitOfWork.UserDocumentRepository.Add(entity);

            _unitOfWork.Save();

            

            //notification
            await _mediator.Publish(new UserDocumentCreated(entity));

            return Unit.Value;
        }

    }
}
