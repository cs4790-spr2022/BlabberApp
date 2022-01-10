using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;
using System.Collections;

namespace BlabberApp.DataStore.Plugins;

public class MySqlBlabRepository : MySqlPlugin, IBlabRepository
{
    public MySqlBlabRepository(string connStr) : base(connStr)
    {
        this.Connect();
    }

    public IDomainEntity GetBlabByUser(User usr)
    {
        throw new NotImplementedException();
    }

    public IEnumerable GetBlabsByDateTime(DateTime Dttm)
    {
        throw new NotImplementedException();
    }

    public void Create(IDomainEntity obj)
    {
        throw new NotImplementedException();
    }

    public IEnumerable ReadAll()
    {
        throw new NotImplementedException();
    }

    public IDomainEntity ReadById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void Update(IDomainEntity obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(IDomainEntity obj)
    {
        throw new NotImplementedException();
    }

    public void DeleteAll()
    {
        throw new NotImplementedException();
    }
}