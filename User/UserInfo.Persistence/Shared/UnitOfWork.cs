using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Application.Interfaces.Persistence;
using UserInfo.Domain.Entities;

namespace UserInfo.Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _database;

        public IRepository<User> UserRepository { get; }
        public IRepository<Address> AddressRepository { get; }
        public IRepository<City> CityRepository { get; }
        public IRepository<Governate> GovernateRepository { get; }
        public UnitOfWork(ApplicationDbContext database
            , IRepository<User> UserRepository
            , IRepository<Address> AddressRepository
            , IRepository<City> CityRepository
            , IRepository<Governate> GovernateRepository
            )
        {
            _database = database;
            this.UserRepository = UserRepository;
            this.AddressRepository = AddressRepository;
            this.CityRepository = CityRepository;
            this.GovernateRepository = GovernateRepository;
        }
        public void Save()
        {
            _database.Save();
        }
    }
}
