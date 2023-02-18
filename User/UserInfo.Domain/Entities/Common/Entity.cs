using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Domain.Entities.Common
{
    public class Entity: IEntity
    {

        [Key]
        public int Id { get; set; }
    }
}
