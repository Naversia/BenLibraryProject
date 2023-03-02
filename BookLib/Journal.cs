using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Journal : AbstractItem 
    {
        [Required]
        public MonthType MonthType { get; set; }
        public Journal(string title, int stock, double price, string authorName, ItemGenreType genre, MonthType monthType) : base(title, stock, price, authorName, genre)
        {
            MonthType = monthType;
        
        }

        //public override bool EqualsItem(AbstractItem abs)
        //{
        //    if (abs is Journal j)
        //        return InternationalStandardCode == j.InternationalStandardCode &&
        //            SheetNumber == j.SheetNumber;
        //    return false;
        //}
    }
}
