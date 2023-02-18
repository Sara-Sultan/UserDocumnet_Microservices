using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;

namespace UserInfo.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Address> AddressRepository { get; }
        IRepository<City> CityRepository { get; }
        IRepository<Governate> GovernateRepository { get; }
        void Save();
    }
}
