using System.Net.Mail;

using Domain.Common.Interfaces;

namespace Domain.Entities;

public class User : IEntity
{
    public DateTime DttmCreated { get; set; }
    public DateTime DttmLastLogin { get; set; }
    public MailAddress? Email { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid Id { get; set; }

    public User(string? username, string? email)
    {
        DttmCreated = DttmLastLogin = DateTime.Now;
        Username = username;
        Email = new MailAddress(email!);
        Id = Guid.NewGuid();
    }

    public bool AreEqual(IEntity u)
    {
        return false;
    }

    public void Validate()
    {
        // TODO is there an email
        // TODO is email format valid
        // TODO username exists
        throw new NotImplementedException();
    }
}