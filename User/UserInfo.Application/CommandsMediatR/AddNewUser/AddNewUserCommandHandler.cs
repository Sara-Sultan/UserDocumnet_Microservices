using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInfo.Application.Events;
using UserInfo.Application.Interfaces.Persistence;
using UserInfo.Application.MessageBus;
using UserInfo.Application.RabbitMQSender;
using UserInfo.Domain.Entities;

namespace UserInfo.Application.CommandsMediatR
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, int>
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRabbitMQUserMessageSender _rabbitMQCartMessageSender;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;

        public AddNewUserCommandHandler(IUnitOfWork unitOfWork
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

        public async Task<int> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            //validation
            var validator = new AddNewUserCommandValidator();
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
            var entity = _mapper.Map<User>(request);

            _unitOfWork.UserRepository.Add(entity);

            _unitOfWork.Save();

            //Call Document Service
            AddNewUserDocumentDto addNewUserDocumentDto = new AddNewUserDocumentDto();
            addNewUserDocumentDto.UserId = entity.Id;
            addNewUserDocumentDto.FilePath = "Test";
            if (_configuration.GetSection("RunAzureBus").Value == "False")
            {
                //rabbitMQ
                _rabbitMQCartMessageSender.SendMessage(addNewUserDocumentDto, "AddNewUserDoc");
            }
            else
            {
                //Azure
                await _messageBus.PublishMessage(addNewUserDocumentDto, "addnewuserdocumnet");
            }
          

            //notification
            await _mediator.Publish(new UserCreated(entity));

            return 1;
        }
    }
}
