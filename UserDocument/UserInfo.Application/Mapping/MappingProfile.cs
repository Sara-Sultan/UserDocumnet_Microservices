using Document.Application.CommandsMediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Application.QueriesMediatR;
using Document.Domain.Entities;

namespace Document.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
           // CreateMap<UserDocument, AddNewUserDocumentCommand>().ReverseMap();
            CreateMap<UserDocument, UserDocumentDisplay>().ReverseMap();

        }
    }
}
