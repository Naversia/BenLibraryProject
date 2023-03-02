using ItemLib.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemLib.Model
{
    public class Book : AbstractItem
    {
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public string ISBN { get; set; }

        public Book(string title, int stock, double price, string authorName, ItemGenreType genre, int publishYear) : base(title, stock, price, authorName, genre)
        {
            ISBN = Guid.NewGuid().ToString();
            PublishYear = publishYear;
        }
    }
}
