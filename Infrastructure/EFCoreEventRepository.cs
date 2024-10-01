using TestTask.Models;

namespace TestTask.Infrastructure
{
    public class EFCoreEventRepository(EventContext eventContext) : IEventRepository, IDisposable
    {
        private bool _disposed = false;
        private readonly EventContext _eventContext = eventContext;

        public void Add(Event @event)
        {
            _eventContext.Add(@event);
        }

        public void Save()
        {
            _eventContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _eventContext.Dispose();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
