using Domain.Common.Interfaces;

namespace Domain.Entities;

public class Blab : IEntity
{
    public string? Content { get; set; }
    public string? Username { get; set; }
    public DateTime DttmCreated { get; set; }
    public DateTime DttmModified { get; set; }
    public Guid Id { get; set; }

    public Blab(string? Msg, string? Usr)
    {
        Content = Msg;
        Username = Usr;
        DttmCreated = DttmModified = DateTime.Now;
        Id = Guid.NewGuid();
    }

    public bool AreEqual(IEntity b)
    {
        return false;
    }

    public void Validate()
    {
        // TODO content exists
        // TODO a user exists
        // throw new InvalidDataException("Blab");
        throw new NotImplementedException();
    }
}