using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Domain.Entities;

namespace Document.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<UserDocument> UserDocumentRepository { get; }
        void Save();
    }
}
