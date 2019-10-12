using AccessOneMonitor.Data.Configuration;
using AccessOneMonitor.Data.Entities;
using AccessOneMonitor.Data.Repositories.Base;
using AccessOneMonitor.Data.Repositories.Interfaces;

namespace AccessOneMonitor.Data.Repositories
{
    public class CommandRepository : GenericRepository<Command>, ICommandRepository
    {
        public CommandRepository(DbContextConfiguration dbContext) : base(dbContext) { }
    }
}
