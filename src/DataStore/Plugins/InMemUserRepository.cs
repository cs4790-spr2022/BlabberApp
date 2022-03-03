using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Common.Interfaces;
using System.Collections.Generic;

namespace BlabberApp.DataStore.Plugins
{
    public class InMemUserRepository : IUserRepository
    {

        private List<User> _buf = new List<User>();

        public int Count()
        {
            return _buf.Count;
        }

        public void Add(User user)
        {
            _buf.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _buf;
        }

        public User GetById(Guid Id)
        {
            foreach (User user in _buf)
            {
                if (Id.Equals(user.Id)) return user;
            }
            throw new Exception("Not found");
        }

        public void Update(User user)
        {
            try
            {
                user.Validate();
                _buf.Remove(user);
                _buf.Add(user);
            }
            catch
            {
                throw new Exception("Something bad happened!");
            }
        }

        public void Remove(User user)
        {
            _buf.Remove(user);
        }

        public void RemoveAll()
        {
            _buf.Clear();
        }
        public User GetByEmail(string email){
            throw new NotImplementedException();
        }
        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}