namespace TestTask.Models
{
    public interface IEventRepository
    {
        void Add(Event @event);
        void Save();
    }
}
