using BlabberApp.Domain.Common.Interfaces;
using System.Net.Mail;
using System;

namespace BlabberApp.Domain.Entities;

public class User : IDomainEntity
{
    public DateTime lastloginDttm { get; }
    public DateTime registeredDttm { get; }
    public MailAddress Email { get; set; }
    public Guid Id { get; }
    public string Username { get; set; }

    public User(string username, string address)
    {
        this.lastloginDttm = this.registeredDttm;
        this.registeredDttm = DateTime.UtcNow;
        this.Email = new MailAddress(address);
        this.Id = Guid.NewGuid();
        this.Username = username;
    }
}