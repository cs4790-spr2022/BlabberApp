using BlabberApp.Domain.Entities;
using System;

namespace BlabberApp.Domain.Common.Interfaces;

public interface IUserRepository : IRepository
{
    IDomainEntity GetByEmail(string email);
}