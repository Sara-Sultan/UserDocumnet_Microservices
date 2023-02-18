using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Domain.Entities.Common;

namespace Document.Domain.Entities
{
    public class UserDocument : Entity
    {
        public int UserId { get; set; }
        public string FilePath { get; set; }
    }
}
