using AccessOneMonitor.Data.Configuration;
using AccessOneMonitor.Data.Entities;
using AccessOneMonitor.Data.Repositories.Base;
using AccessOneMonitor.Data.Repositories.Interfaces;

namespace AccessOneMonitor.Data.Repositories
{
    public class ProcessRepository : GenericRepository<Process>, IProcessRepository
    {
        public ProcessRepository(DbContextConfiguration dbContext) : base(dbContext) { }
    }
}
