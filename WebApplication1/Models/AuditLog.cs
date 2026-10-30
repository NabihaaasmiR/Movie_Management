namespace WebApplication1.Models
{
    /// <summary>
    /// Represents an audit log entry for tracking system operations and timestamps.
    /// </summary>
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}