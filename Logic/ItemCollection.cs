using BookLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ItemCollection
    {

        public ObservableCollection<AbstractItem> ItemsList { get; set; }

        public ItemGenreType SelectedGenre { get; set; }


        public ItemCollection() => SetData();

        //public Action<AbstractItem> DeleteItemAction { get; set; }
        public Func<AbstractItem> RemoveItemFunc { get; set; }

        public Action<AbstractItem> AddAction { get; set; }
        public Func<AbstractItem> AddItemFunc { get; set; }

        public void RemoveItemFromList(AbstractItem itemToRemove) => ItemsList.Remove(itemToRemove);

        private void SetData()
        {
            ItemsList = new ObservableCollection<AbstractItem>()    //string title, int stock, double price, string authorName, ItemGenreType genre, int publishYear)
            {
                new Book("Harry Potter - 2", 1, 110,  "LoDGlo",  ItemGenreType.Fantasy, 2002) { Id = 1 },
                new Book("Harry Potter - 3",  1, 110,  "LoDGlo",  ItemGenreType.Fantasy, 2003) { Id = 2},
                new Book("Harry Potter - 4", 1, 115 ,"LoGRlo", ItemGenreType.Fantasy, 2008) { Id = 3 },
                new Book("Harry Potter - 5", 1, 119 , "LGFGFolo", ItemGenreType.Fantasy, 2009) { Id = 4 },
                new Book("Harry Potter - 6", 1, 119, "klkek", ItemGenreType.Fantasy, 2010) { Id = 5 },
                //string title, int stock, double price, string authorName, ItemGenreType genre, MonthType monthType
                new Journal("Tesla", 1, 25, "Lolo Man", ItemGenreType.Car, MonthType.Apr ) { Id = 6 },
                new Journal("Koko", 1, 40, "Food Man", ItemGenreType.Food, MonthType.May) { Id = 7 },
                new Journal("Shushu", 1, 15, "Shushu Man", ItemGenreType.Action, MonthType.Jan) { Id = 8 },
            };
        }
        //public ObservableCollection<AbstractItem> RemoveFromList()
        //{
        //        ItemsList.Remove(RemoveItemFunc());
        //   return RefreshList();
        //}

        //public ObservableCollection<AbstractItem> AddToList()
        //{
        //    ItemsList.Add(AddItemFunc());
        //    return RefreshList();
        //}


        public ObservableCollection<AbstractItem> RefreshList()
        {
            ObservableCollection<AbstractItem>  NewItemsList = new ObservableCollection<AbstractItem>();
            foreach (var item in ItemsList)
            {
                NewItemsList.Add(item);
            }
            return NewItemsList;
        }
        public bool AddItem(string title, int stock, double price, string authorName, ItemGenreType genre, int publishYear)
        {
            Book nb = new Book(title, stock, price, authorName, genre, publishYear) { Title = title, Stock = stock, Price = price, AuthorName = authorName, Genre = genre, PublishYear = publishYear };
            ItemsList.Add(nb);
            RefreshList();
            return true;
        }

        public bool CheckInLib(string title)
        {
            foreach (var item in ItemsList)
            {
                if (item.Title.ToLower() == title.ToLower())
                {
                    item.Stock++;
                    return false;
                }
            }
            return true;
        }




        public IEnumerable<AbstractItem> GetItems() => ItemsList;
        public IEnumerable<AbstractItem> GetByTitle(IEnumerable<AbstractItem> items, string title) => items.Where(i => i.Title.Contains(title));
        //public IEnumerable<string> AuthorName() => ItemsList.Where(i => i.AuthorName != null);
        public IEnumerable<AbstractItem> GetByPrice(IEnumerable<AbstractItem> items, int price) => items.Where(i => i.Price == price);

        public IEnumerable<AbstractItem> GetByPublisher(IEnumerable<AbstractItem> items, string authorName) => items.Where(i => i.AuthorName.ToLower() == authorName.ToLower());


    }
}
