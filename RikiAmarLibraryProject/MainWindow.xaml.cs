using System;
using System.Text;
using System.Windows;


namespace BenEliLibraryProject
{
    public partial class MainWindow : Window
    {
        //Service service
        public MainWindow()
        {
            InitializeComponent();
            //TestSqlConnection();
        }

        //    private void TestSqlConnection()
        //    {
        //        try
        //        {


        //            Console.WriteLine("\nQuery data example:");
        //            Console.WriteLine("=========================================\n");

        //            String sql = "SELECT name, collation_name FROM sys.databases";

        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
        //                    }
        //                }
        //            }

        //        }
        //        catch (SqlException e)
        //        {
        //            Console.WriteLine(e.ToString());
        //        }
        //        Console.ReadLine();
        //    }
    }

}
