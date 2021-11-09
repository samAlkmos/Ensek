using Ensek.DAL.DataContext;
using Ensek.DAL.Repositories.IRepositories;
using Ensek.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.DAL.Repositories
{
    public class MeterReadingRepository : GenericRepository<MeterReadingModel>, IMeterReadingRepository
    {
        private readonly EnsekDbContext _ensekDbContext;
        public MeterReadingRepository(EnsekDbContext ensekDbContext) : base(ensekDbContext)
        {
            _ensekDbContext = ensekDbContext;
        }
    }
}
