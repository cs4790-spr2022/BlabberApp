using BlabberApp.Domain.Common.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : BaseEntity
    {
        public string Content { get; set; }
        public User Author { get; set; }

        public Blab(string Msg, User Usr)
        {
            Content = Msg;
            Author = Usr;
        }

        override public void AreEqual(IEntity blab)
        {
            throw new NotImplementedException();
        }

        override public void Validate()
        {
            // TODO content exists
            // TODO a user exists
            // throw new InvalidDataException("Blab");
            throw new NotImplementedException();
        }
    }
}