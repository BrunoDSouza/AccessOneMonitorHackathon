using AccessOneMonitor.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessOneMonitor.Services
{
    public interface IMonitorService
    {
        IEnumerable<Command> GetAllCommands();
        IEnumerable<Computer> GetAllComputers();
        IEnumerable<Execution> ExecuteCommand(long commandId, IEnumerable<long> computers);
        Task SchedulerCommand(Command command, IEnumerable<long> computers);
    }
}
