using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities.Common;

namespace UserInfo.Domain.Entities
{
    public class City: Entity
    {
        [MaxLength(256)]
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
