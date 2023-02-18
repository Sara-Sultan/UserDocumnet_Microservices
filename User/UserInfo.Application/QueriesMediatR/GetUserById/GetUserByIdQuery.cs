using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.QueriesMediatR
{
    public class GetUserByIdQuery : IRequest<UserDisplay>
    {
        public int Id { get; set; }
    }
}
