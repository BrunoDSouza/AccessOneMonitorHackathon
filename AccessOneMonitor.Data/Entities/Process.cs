namespace AccessOneMonitor.Data.Entities
{
    public class Process : Entity
    {
        public Process() { }

        public string Name { get; set; }
        public string MemoryAllocation { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}
