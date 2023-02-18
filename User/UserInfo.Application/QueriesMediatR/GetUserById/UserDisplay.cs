using UserInfo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.QueriesMediatR
{
    public class UserDisplay : IResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public ICollection<AddressDisplay> Addresses { get; set; }
    }
}
