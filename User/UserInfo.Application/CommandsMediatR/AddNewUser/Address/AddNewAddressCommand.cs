using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.CommandsMediatR
{
    public class AddNewAddressCommand : IRequest<int>
    {
        public int GovernateId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
