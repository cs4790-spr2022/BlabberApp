using System.Collections;

using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;

using MySql.Data.MySqlClient;

namespace BlabberApp.DataStore.Plugins;
public class MySqlBlabRepository : MySqlPlugin, IBlabRepository
{
    private readonly MySql.Data.MySqlClient.MySqlCommand _cmd;

    public MySqlBlabRepository(string connStr) : base(connStr)
    {
        _cmd = new MySql.Data.MySqlClient.MySqlCommand();
    }

    public void Add(Blab blab)
    {
        try
        {
            _cmd.CommandText = "INSERT INTO `donstringham`.`blabs` (sys_id, dttm_created, dttm_modified, content, usr) VALUES (@SysId, @Created, @Modified, @Content, @Usr)";
            _cmd.Prepare();
            _cmd.Parameters.AddWithValue("@SysId", blab.Id);
            _cmd.Parameters.AddWithValue("@Created", blab.DttmCreated);
            _cmd.Parameters.AddWithValue("@Modified", blab.DttmModified);
            _cmd.Parameters.AddWithValue("@Content", blab.Content);
            _cmd.Parameters.AddWithValue("@Usr", blab.Author);
            _cmd.ExecuteNonQuery();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            // MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new Exception("Error " + ex.Number + " has occurred: " + ex.Message);
        }
    }

    public IEnumerable<Blab> GetAll()
    {
        throw new NotImplementedException();
    }

    public Blab GetById(Guid Id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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