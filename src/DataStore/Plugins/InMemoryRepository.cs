using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;
using System.Collections;

namespace BlabberApp.DataStore.Plugins{

public class InMemoryRepository : IRepository, IBlabRepository, IUserRepository
{
    // public ArrayList Buffer;
    private IEntity[] buffer;

    public InMemoryRepository()
    {
        this.Buffer = new ArrayList();
    }

    public int Count()
    {
        return this.Buffer.Count;
    }

    public void Create(IDomainEntity obj)
    {
        this.Buffer.Add(obj);
    }

    public IEnumerable ReadAll()
    {
        return this.Buffer;
    }

    public IDomainEntity ReadById(Guid Id)
    {
        foreach (IDomainEntity obj in this.Buffer)
        {
            if (Id.Equals(obj.Id)) return obj;
        }
        throw new Exception("Not found");
    }

    // public void UpdateById(IDomainEntity obj)
    public void UpdateById(IDomainEntity obj)
    {
        // TODO Validation of "obj"
        try {
            obj.Validate();
            this.Delete(obj);
            this.Create(obj);
        } catch {
            throw;
        }
    }

    public void Delete(IDomainEntity obj)
    {
        this.Buffer.Remove(obj);
    }

    public void DeleteAll()
    {
        this.Buffer.Clear();
    }

    public IDomainEntity GetBlabByUser(User usr) { throw new NotImplementedException(); }
    public IEnumerable GetBlabsByDateTime(DateTime Dttm) { throw new NotImplementedException(); }
    public IDomainEntity GetByEmail(string email) { throw new NotImplementedException(); }
}
}