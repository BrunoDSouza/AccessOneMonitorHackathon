using AccessOneMonitor.Data.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessOneMonitor.Data.Entities
{
    public class Command : Entity
    {
        public string Name { get; set; }
        public CommandType Type { get; set; }
        public string Value { get; set; }

        public IEnumerable<Execution> Executions { get; set; }
    }
}
