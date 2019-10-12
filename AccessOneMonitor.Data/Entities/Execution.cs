using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessOneMonitor.Data.Entities
{
    public class Execution : Entity
    {
        public Execution() { }

        public Computer Computer { get; set; }
        public long ComputerId { get; set; }
        public Process Process { get; set; }
        public long ProcessId { get; set; }
    }
}
