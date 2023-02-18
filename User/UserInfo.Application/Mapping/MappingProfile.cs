using UserInfo.Application.CommandsMediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Application.QueriesMediatR;
using UserInfo.Domain.Entities;

namespace UserInfo.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, AddNewUserCommand>().ReverseMap();
            CreateMap<User, UserDisplay>().ReverseMap();

            CreateMap<Address, AddNewAddressCommand>().ReverseMap();
            CreateMap<Address, AddressDisplay>().ReverseMap();
        }
    }
}
