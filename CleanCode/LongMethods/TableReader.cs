using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class TableReader
{
    public DataTable GetDataTable()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [FooFoo] ORDER BY id ASC", sqlConnection);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet, "FooFoo");
        DataTable dataTable = dataSet.Tables["FooFoo"];
        return dataTable;
    }
}