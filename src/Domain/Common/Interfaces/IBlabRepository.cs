using BlabberApp.Domain.Entities;
using System.Collections;

namespace BlabberApp.Domain.Common.Interfaces;

public interface IBlabRepository : IRepository
{
    IDomainEntity GetBlabByUser(User usr);
    IEnumerable GetBlabsByDateTime(DateTime Dttm);
}