using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IBlabRepository : IRepository<Blab>
{
    public IEnumerable<Blab> GetByUser(User usr);

    public IEnumerable<Blab> GetByDateTime(DateTime Dttm);
    // public IEnumerable<Blab> GetAllSortedBy(string colName, string order);
}