using BlabberApp.Domain.Entities;
using System.Collections;

namespace BlabberApp.Domain.Common.Interfaces
{
    public interface IBlabRepository : IRepository
    {
        IEntity GetBlabsByUser(User usr);
    }
}