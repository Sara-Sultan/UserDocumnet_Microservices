using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.RabbitMQSender
{
    public class AddNewUserDocumentDto : BaseMessage
    {
        public int UserId { get; set; }
        public string FilePath { get; set; }
    }
}
