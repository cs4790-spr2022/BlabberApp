using System.Data;

using Domain.Common.Interfaces;
using Domain.Entities;

using MySql.Data.MySqlClient;

namespace DataStore.Plugins;

public class MySqlUserRepository : MySqlPlugin, IUserRepository
{
    private readonly MySqlCommand _cmd;
    private static string _dbname = "`donstringham`";
    private static string _tbname = "`user`";
    private readonly string _srcname = _dbname + "." + _tbname;


    public MySqlUserRepository(string connStr) : base(connStr)
    {
        _cmd = new MySqlCommand();
        _cmd.Connection = this.Conn;
    }

    public void Add(User user)
    {
        try
        {
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();
            _cmd.CommandText = "INSERT INTO " + _srcname +
                               " (sys_id, dttm_created, dttm_lastlogin, email, username, first_name, last_name) VALUES" +
                               " (?, ?, ?, ?, ?, ?, ?)";
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("param1", user.Id);
            _cmd.Parameters.AddWithValue("param2", user.DttmCreated);
            _cmd.Parameters.AddWithValue("param3", user.DttmLastLogin);
            _cmd.Parameters.AddWithValue("param4", user.Email);
            _cmd.Parameters.AddWithValue("param5", user.Username);
            _cmd.Parameters.AddWithValue("param6", user.FirstName);
            _cmd.Parameters.AddWithValue("param7", user.LastName);

            _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
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
        if (_cmd.Connection.State == ConnectionState.Closed)
            _cmd.Connection.Open();
        _cmd.CommandText = "SELECT sys_id, email, username, first_name, last_name FROM " + _srcname;
        var reader = _cmd.ExecuteReader();
        List<User> buf = new();

        while (reader.Read())
        {
            User u = new(reader.GetString(2), reader.GetString(1))
            {
                Id = new Guid(reader.GetString(0)), FirstName = reader.GetString(3), LastName = reader.GetString(4)
            };

            buf.Add(u);
        }
        reader.Close();

        return buf;
    }

    public User GetById(Guid id)
    {
        try
        {
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();

            _cmd.CommandText = "SELECT sys_id, email, username, first_name, last_name " +
                               "FROM " + _srcname + " WHERE " + _srcname + ".`sys_id` " +
                               "LIKE '" + id + "'";

            var reader = _cmd.ExecuteReader();
            reader.Read();
            User res = new(reader.GetString(2), reader.GetString(1)) {Id = new Guid(reader.GetString(0))};
            reader.Close();

            return res;
        }
        catch (MySqlException ex)
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
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();
            // TODO SQL will change.
            _cmd.CommandText = "TRUNCATE " + _srcname;
            _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
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