using BlabberApp.Domain.Common.Interfaces;

namespace BlabberApp.Domain.Entities;

public class Blab : IDomainEntity
{
    public string Content { get; set; }
    public Guid Id { get; set; }
    public User User { get; set; }

    public Blab(string Msg, User Usr)
    {
        this.Content = Msg;
        this.Id = Guid.NewGuid();
        this.User = Usr;
    }
}