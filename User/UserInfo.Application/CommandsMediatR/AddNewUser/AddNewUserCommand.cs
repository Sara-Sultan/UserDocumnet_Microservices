using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserInfo.Application.RabbitMQSender;

namespace UserInfo.Application.CommandsMediatR
{
    public class AddNewUserCommand :IRequest<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public IList<AddNewAddressCommand> Addresses { get; set; }
    }
}
