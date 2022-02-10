namespace BlabberApp.Domain.Common.Interfaces
{

    public interface IUserRepository : IRepository
    {
        IEntity GetByEmail(string email);
        IEntity GetByUsername(string username);
    }
}