using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessOneMonitor.Data.Entities
{
    public class Computer : Entity
    {
        public Computer() { }

        public string HostName { get; set; }
        public string Ip { get; set; }
        public long FreeSpace { get; set; }
        public IEnumerable<Process> Processes { get; set; }
    }
}
