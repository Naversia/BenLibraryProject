using BookLib;
using System.Data.SqlClient;
namespace BenEliLibraryProject.Service
{
    public class BookService
    {
        private DBConnection DBConnection = DBConnection.GetInstance();
        public void Add(string title, int stock, double price, string authorName, ItemGenreType genre, int publishYear)
        {
            Book book = new Book
            (
                title,
                stock,
                price,
                 authorName,
                genre,
                publishYear
            );

            SqlCommand cmd = new SqlCommand("Insert into ", DBConnection.Connection);

            //using (var db = new BookLibraryContext())
            //{
            //    db.Books.Add(book);
            //    db.SaveChanges();
            //}
        }

        public void Add(string title, int stock, double price, string authorName, ItemGenreType genre, MonthType monthType)
        {
            var journal = new Journal(title, stock, price, authorName, genre, monthType);

        }
    }
}