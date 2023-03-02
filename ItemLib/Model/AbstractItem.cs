using ItemLib.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemLib.Model
{
    public abstract class AbstractItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Stock { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public ItemGenreType Genre { get; set; }
        //public MonthType MonthType { get; set; }

        public AbstractItem(string title, int stock, double price, string authorName, ItemGenreType genre)
        {
            Title = title;
            Stock = stock;
            Price = price;
            AuthorName = authorName;
            Genre = genre;
        }

        //public static implicit operator ItemGenreType(AbstractItem v)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual bool EqualsItem(AbstractItem abs) => Id == abs.Id;//??

    }
}
