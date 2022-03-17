
using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;

using MySql.Data.MySqlClient;

namespace BlabberApp.DataStore.Plugins;
public class MySqlUserRepository : MySqlPlugin, IUserRepository
{
    private readonly MySql.Data.MySqlClient.MySqlCommand _cmd;
    private static string _dbname = "`donstringham`";
    private static string _tbname = "`user`";
    private readonly string _srcname = _dbname + "." + _tbname;


    public MySqlUserRepository(string connStr) : base(connStr)
    {
        _cmd = new MySql.Data.MySqlClient.MySqlCommand();
        _cmd.Connection = this.Conn;
    }

    public void Add(User user)
    {
        try
        {
            _cmd.Connection.Open();
            // TODO SQL will change.
            _cmd.CommandText = "INSERT INTO " + _srcname +
            " (sys_id, dttm_created, dttm_modified, content, usr) VALUES" +
            " (?, ?, ?, ?, ?)";
            _cmd.Parameters.AddWithValue("param1", user.Id);
            _cmd.Parameters.AddWithValue("param2", user.DttmLastLogin);
            _cmd.Parameters.AddWithValue("param3", user.Email);
            _cmd.Parameters.AddWithValue("param4", user.Username);
            _cmd.Parameters.AddWithValue("param5", user.FirstName);
            _cmd.Parameters.AddWithValue("param6", user.LastName);

            _cmd.ExecuteNonQuery();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetById(Guid id)
    {
        try
        {
            _cmd.Connection.Open();

            // TODO SQL will change.
            _cmd.CommandText = "SELECT sys_id, dttm_created, dttm_modified, content, usr " +
            "FROM " + _srcname + " WHERE " + _srcname + ".`sys_id` " +
            "LIKE '" + id.ToString() + "'";

            var reader = _cmd.ExecuteReader();
            reader.Read();
            User res = new User(reader.GetString(4), "foo@bar.com");
            res.Id = new Guid(reader.GetString(0));

            return res;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public void Update(User u)
    {
        throw new NotImplementedException();
    }

    public void Remove(User u)
    {
        throw new NotImplementedException();
    }

    public void RemoveAll()
    {
        try
        {
            _cmd.Connection.Open();
            // TODO SQL will change.
            _cmd.CommandText = "TRUNCATE " + _srcname;
            _cmd.ExecuteNonQuery();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public User GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
    public User GetByUsername(string username)
    {
        throw new NotImplementedException();
    }
}