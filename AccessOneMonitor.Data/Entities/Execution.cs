using AccessOneMonitor.Data.Types;
using System;
using System.Collections.Generic;

namespace AccessOneMonitor.Data.Entities
{
    public class Execution : Entity
    {
        public Execution() { }

        public Computer Computer { get; set; }
        public long ComputerId { get; set; }
        public Command Command { get; set; }
        public long CommandId { get; set; }
        public string Output { get; set; }
        public ExecutionStatusType Status { get; set; }
        public DateTime? DateExecution { get; set; }
    }
}
