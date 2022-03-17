using System.Collections;

using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;

using MySql.Data.MySqlClient;

namespace BlabberApp.DataStore.Plugins;
public class MySqlBlabRepository : MySqlPlugin, IBlabRepository
{
    private readonly MySql.Data.MySqlClient.MySqlCommand _cmd;
    private static string _dbname = "`donstringham`";
    private static string _tbname = "`blabs`";
    private readonly string _srcname = _dbname + "." + _tbname;


    public MySqlBlabRepository(string connStr) : base(connStr)
    {
        _cmd = new MySql.Data.MySqlClient.MySqlCommand();
        _cmd.Connection = this.Conn;
    }

    public void Add(Blab blab)
    {
        try
        {
            _cmd.Connection.Open();

            _cmd.CommandText = "INSERT INTO " + _srcname +
            " (sys_id, dttm_created, dttm_modified, content, usr) VALUES" +
            " (?, ?, ?, ?, ?)";
            _cmd.Parameters.AddWithValue("param1", blab.Id);
            _cmd.Parameters.AddWithValue("param2", blab.DttmCreated);
            _cmd.Parameters.AddWithValue("param3", blab.DttmModified);
            _cmd.Parameters.AddWithValue("param4", blab.Content);
            _cmd.Parameters.AddWithValue("param5", blab.Author.Username);

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

    public IEnumerable<Blab> GetAll()
    {
        throw new NotImplementedException();
    }

    public Blab GetById(Guid Id)
    {
        try
        {
            _cmd.Connection.Open();

            _cmd.CommandText = "SELECT sys_id, dttm_created, dttm_modified, content, usr " +
            "FROM " + _srcname + " WHERE " + _srcname + ".`sys_id` " +
            "LIKE '" + Id.ToString() + "'";

            var reader = _cmd.ExecuteReader();
            reader.Read();
            User u = new User(reader.GetString(4), "foo@bar.com"); // This will be modified soon.
            Blab res = new Blab(reader.GetString(3), u);
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

    public void Update(Blab blab)
    {
        throw new NotImplementedException();
    }

    public void Remove(Blab blab)
    {
        throw new NotImplementedException();
    }

    public void RemoveAll()
    {
        try
        {
            _cmd.Connection.Open();
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

    public IEnumerable<Blab> GetByUser(User usr)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Blab> GetByDateTime(DateTime dttm)
    {
        throw new NotImplementedException();
    }
}