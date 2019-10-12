using AccessOneMonitor.Data.Configuration;
using AccessOneMonitor.Data.Entities;
using AccessOneMonitor.Data.Repositories.Base;
using AccessOneMonitor.Data.Repositories.Interfaces;

namespace AccessOneMonitor.Data.Repositories
{
    public class ComputerRepository : GenericRepository<Computer>, IComputerRepository
    {
        public ComputerRepository(DbContextConfiguration dbContext) : base(dbContext) { }
    }
}
