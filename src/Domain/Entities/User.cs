using BlabberApp.Domain.Common.Interfaces;
using System.Net.Mail;

namespace BlabberApp.Domain.Entities;

    public class User : BaseEntity
    {
        public DateTime? DttmLastLogin { get; set;}
        public MailAddress? Email { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public User(string username, string email)
        {
            this.DttmLastLogin = DateTime.Now;
            this.Email = new MailAddress(email);
            this.Username = username;
        }

        override public void AreEqual(IEntity blab)
        {
            throw new NotImplementedException();
        }

        override public void Validate()
        {
            // TODO is there an email
            // TODO is email format valid
            // TODO username exists
            throw new NotImplementedException();
        }
    }