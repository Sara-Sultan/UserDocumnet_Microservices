using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;

namespace UserInfo.Persistence.Shared
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext ApplicationDbContext;

        public DataSeeder(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }

        public void Seed()
        {
            if (!ApplicationDbContext.Cities.Any())
            {
                var Cities = new List<City>()
                {
                    new City
                    {
                        Name = "Cairo"
                    },
                    new City
                    {
                        Name = "Giza"
                    }
                };

                ApplicationDbContext.Cities.AddRange(Cities);
                ApplicationDbContext.SaveChanges();
            }

            if (!ApplicationDbContext.Governates.Any())
            {
                var Governates = new List<Governate>()
                {
                    new Governate
                    {
                        Name = "Egypt"
                    },
                    new Governate
                    {
                        Name = "SA"
                    }
                };

                ApplicationDbContext.Governates.AddRange(Governates);
                ApplicationDbContext.SaveChanges();
            }
        }
    }
}
