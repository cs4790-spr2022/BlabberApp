using BlabberApp.Domain.Common.Interfaces;
using System;

namespace BlabberApp.Domain.Entities;

public class Blab : IDomainEntity
{
    public string Content { get; set; }
    public Guid Id {get;}
    public User User { get; set; }

    public Blab(string Msg, User Usr)
    {
        this.Content = Msg;
        this.Id = Guid.NewGuid();
        this.User = Usr;
    }
}