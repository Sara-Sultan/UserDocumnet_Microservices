using UserInfo.Application.Events;
using UserInfo.Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInfo.Application.Interfaces.Persistence;
using UserInfo.Application.RabbitMQSender;
using UserInfo.Application.MessageBus;
using Microsoft.Extensions.Configuration;

namespace UserInfo.Application.CommandsMediatR
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRabbitMQUserMessageSender _rabbitMQCartMessageSender;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        public DeleteUserCommandHandler(IUnitOfWork unitOfWork
            , IMapper mapper, IMediator mediator
              , IRabbitMQUserMessageSender rabbitMQCartMessageSender
            , IMessageBus messageBus
            , IConfiguration configuration

            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rabbitMQCartMessageSender = rabbitMQCartMessageSender;
            _mediator = mediator;
            _messageBus = messageBus;
            _configuration = configuration;

        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var User = _unitOfWork.UserRepository.Get(request.Id);
            if (User == null)
                throw new NotFoundException(nameof(User), request.Id);

            _unitOfWork.UserRepository.Remove(User);
            
            _unitOfWork.Save();

            //Call Document Service
            RemoveUserDocumentDto removeUserDocumentDto = new RemoveUserDocumentDto();
            removeUserDocumentDto.UserId = request.Id;
        
           

            if (_configuration.GetSection("RunAzureBus").Value == "False")
            {
                //rabbitMQ
                _rabbitMQCartMessageSender.SendMessage(removeUserDocumentDto, "RemoveUserDoc");
            }
            else
            {
                //Azure
                await _messageBus.PublishMessage(removeUserDocumentDto, "deleteuserdocument");
            }

            //notification
            await _mediator.Publish(new UserDeleted(User));

            return Unit.Value;
        }

    }
}
