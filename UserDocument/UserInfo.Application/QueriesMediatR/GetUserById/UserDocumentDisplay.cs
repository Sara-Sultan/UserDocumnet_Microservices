using Document.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.QueriesMediatR
{
    public class UserDocumentDisplay : IResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }
    }
}
