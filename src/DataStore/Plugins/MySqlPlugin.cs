namespace DataStore.Plugins;

public class MySqlPlugin
{
    public readonly MySql.Data.MySqlClient.MySqlConnection Conn;

    public MySqlPlugin(string connStr)
    {
        this.Conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
    }

    public void Dispose()
    {
        this.Conn.Close();
    }
}