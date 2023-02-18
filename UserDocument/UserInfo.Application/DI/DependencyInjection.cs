using Document.Application.CommandsMediatR;
using Document.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Application.Mapping;
using Document.Application.QueriesMediatR;
using Document.Application.RabbitMQSender;
using Document.Application.Messaging;
using Document.Application.MessageBus;
using Microsoft.Extensions.Configuration;

namespace Document.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            // services.AddTransient<ICreateUserCommand, CreateUserCommand>();



            services.AddMediatR(new Type[]
              {
                typeof(AddNewUserDocumentCommand),
                typeof(DeleteUserDocumentCommand),
                typeof(GetUserDocumentByUserIdQuery),
              });
            services.AddSingleton<IRabbitMQUserMessageSender, RabbitMQUserMessageSender>();

            if (configuration.GetSection("RunAzureBus").Value== "False")
            {
                services.AddHostedService<RabbitMQAddNewUserDocConsumer>();
                services.AddHostedService<RabbitMQRemoveUserDocConsumer>();
            }


            services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();
            services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();

            return services;
        }
    }
}
