using System;

namespace BlabberApp.Domain.Common.Interfaces;

public interface IDomainEntity {
   Guid Id { get; }
}