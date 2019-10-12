using AccessOneMonitor.Data.Configuration;
using AccessOneMonitor.Data.Entities;
using AccessOneMonitor.Data.Repositories.Base;
using AccessOneMonitor.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccessOneMonitor.Data.Repositories
{
    public class ExecutionRepository : GenericRepository<Execution>, IExecutionRepository
    {
        public ExecutionRepository(DbContextConfiguration dbContext) : base(dbContext) { }
    }
}
