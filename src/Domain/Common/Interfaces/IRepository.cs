using BlabberApp.Domain.Entities;
using System;
using System.Collections;

namespace BlabberApp.Domain.Common.Interfaces;

public interface IRepository
{
    void Create(IDomainEntity obj);
    IEnumerable ReadAll();
    IDomainEntity ReadById(Guid Id);
    void Update(IDomainEntity obj);
    void Delete(IDomainEntity obj);
    void DeleteAll();
}