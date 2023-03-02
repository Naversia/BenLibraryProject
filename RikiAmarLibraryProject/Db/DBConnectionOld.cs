//using BookLib;
//using System.Data.Entity;

//public class BookLibraryContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Journal> Journals { get; set; }

//    public BookLibraryContext() : base("BookLibraryDbConnectionString")
//    {
//    }
//}

using System.Data.SqlClient;
class Example
{
    public void foo()
    {
        DBConnection DBConnection = DBConnection.GetInstance();
        //DBConnection.Connection;
    }

}
public class DBConnection
{
    public SqlConnection Connection { get; private set; }
    private static DBConnection DBInstance = new DBConnection();

    public static DBConnection GetInstance()
    {
        return DBInstance;
    }
    private DBConnection()
    {
        OpenDbConnection();
    }

 
    private void OpenDbConnection()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "(localdb)/MSSQLLocalDB.database.windows.net";
        builder.UserID = "benjaman";
        builder.Password = "BenBenjaman";
        builder.InitialCatalog = "myDataBase";

        Connection = new SqlConnection(builder.ConnectionString);
        Connection.Open();
    }
}
