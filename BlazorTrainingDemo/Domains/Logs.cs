namespace BlazorTrainingDemo.Domains
{
    public class Logs
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string EventType { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
