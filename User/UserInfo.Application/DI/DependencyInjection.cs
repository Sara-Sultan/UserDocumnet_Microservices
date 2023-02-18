using UserInfo.Application.CommandsMediatR;
using UserInfo.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Application.Mapping;
using UserInfo.Application.QueriesMediatR;
using UserInfo.Application.RabbitMQSender;
using UserInfo.Application.MessageBus;

namespace UserInfo.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
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
                typeof(AddNewUserCommand),
                typeof(DeleteUserCommand),
                typeof(GetUserByIdQuery),
            });
            services.AddSingleton<IRabbitMQUserMessageSender, RabbitMQUserMessageSender>();
            services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();

            return services;
        }
    }
}
