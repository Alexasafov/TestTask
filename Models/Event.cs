namespace TestTask.Models
{
    public class Event(string data)
    {
        public int Id { get; private set; }
        public string Data { get; init; } = data;
    }
}
