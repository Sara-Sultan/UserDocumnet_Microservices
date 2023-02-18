using UserInfo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.QueriesMediatR
{
    public class AddressDisplay 
    {
        public int Id { get; set; }
        public int GovernateId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
