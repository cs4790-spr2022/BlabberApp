using System.Collections;

namespace BlabberApp.Domain.Common.Interfaces
{
    public interface IRepository
    {
        void Add(IEntity entity);
        void Remove(IEntity entity);
        void RemoveAll();
        void Update(IEntity entity);
        IEnumerable GetAll();
        IEntity GetById(Guid Id);
    }
}