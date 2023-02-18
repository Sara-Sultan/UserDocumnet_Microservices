using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document.Application.Interfaces.Persistence;
using Document.Domain.Entities;

namespace Document.Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _database;

        public IRepository<UserDocument> UserDocumentRepository { get; }
        public UnitOfWork(ApplicationDbContext database
            , IRepository<UserDocument> UserDocumentRepository
            )
        {
            _database = database;
            this.UserDocumentRepository = UserDocumentRepository;
        }
        public void Save()
        {
            _database.Save();
        }
    }
}
