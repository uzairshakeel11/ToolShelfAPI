namespace ToolShelfAPI
{
    public class ToolList
    {
        public int ToolId { get; set; }

        public required string ToolName { get; set; }
        public required string ToolDescription { get; set; }

        public int ToolAvailable { get; set; }

        public string? PhotoLink { get; set; }
    }
}
