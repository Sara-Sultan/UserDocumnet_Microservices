using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities.Common;

namespace UserInfo.Domain.Entities
{
    public class Address: Entity
    {
       
        public int GovernateId { get; set; }
        //[ForeignKey("GovernateId")]
        public virtual Governate Governate { get; set; }

        public int CityId { get; set; }
       // [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int UserId { get; set; }
       // [ForeignKey("UserId")]
        public virtual User User { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
