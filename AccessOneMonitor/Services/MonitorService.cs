using AccessOneMonitor.Data.Entities;
using AccessOneMonitor.Data.Repositories.Interfaces;
using AccessOneMonitor.Data.Types;
using AccessOneMonitor.Services;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessOneMonitor.Api.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IComputerRepository _computerRepository;
        private readonly IExecutionRepository _executionRepository;

        public MonitorService(ICommandRepository commandRepository, IComputerRepository computerRepository, IExecutionRepository executionRepository)
        {
            _commandRepository = commandRepository;
            _computerRepository = computerRepository;
            _executionRepository = executionRepository;
        }

        public IEnumerable<Execution> ExecuteCommand(long commandId, IEnumerable<long> computers)
        {
            var command = _commandRepository.GetById(1).GetAwaiter().GetResult();

            var execucoes = computers.ToList()
                .Aggregate(new List<Execution>(), (acc, computerId) =>
                {
                    var computer = _computerRepository.GetById(computerId).GetAwaiter().GetResult();
                    try
                    {
                        using (var client = new SshClient(computer.Ip, "linux3", "linux3"))
                        {
                            client.Connect();
                            var cmd = client.RunCommand(command.Value);
                            client.Disconnect();

                            acc.Add(new Execution
                            {
                                Command = command,
                                CommandId = command.Id,
                                Computer = computer,
                                ComputerId = computerId,
                                Output = cmd.Result,
                                Status = ExecutionStatusType.Processed,
                                DateExecution = DateTime.Now
                            });

                            return acc;
                        }
                    }
                    catch (Exception ex)
                    {
                        acc.Add(new Execution
                        {
                            Command = command,
                            CommandId = command.Id,
                            Computer = computer,
                            ComputerId = computerId,
                            Output = ex.Message,
                            Status = ExecutionStatusType.Error,
                            DateExecution = DateTime.Now
                        });
                        return acc;
                    }
                });

            _executionRepository.Create(execucoes);
            return execucoes;
        }

        public Task SchedulerCommand(Command command, IEnumerable<long> computers)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
            => _commandRepository.GetAll().ToList();

        public IEnumerable<Computer> GetAllComputers()
            => _computerRepository.GetAll().ToList();
    }
}
