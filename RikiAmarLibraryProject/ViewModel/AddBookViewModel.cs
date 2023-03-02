using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BenEliLibraryProject.ViewModel
{

    public class AddBookViewModel : ViewModelBase
    {
        private Visibility ucVisibility;
        public Visibility UcVisibility { get => ucVisibility; set => Set(ref ucVisibility, value); }

        public IEnumerable<ItemType> Types { get { return Enum.GetValues(typeof(ItemType)).Cast<ItemType>(); } }


        private AbstractItem selectedItem;
        public AbstractItem SelectedItem { get => selectedItem; set => Set(ref selectedItem, value); }

        public ItemCollection Item { get; set; }
        public ObservableCollection<AbstractItem> Itemlist { get; set; }

        public RelayCommand AddBookCommand { get; set; }

        public AddBookViewModel(ItemCollection item)
        {
            Item = item;
            Itemlist = item.ItemsList;
            SelectedItem = new Book("Harry Potter - 2", 1, 110,  "LoDGlo",  ItemGenreType.Fantasy, 2002);
            UcVisibility = Visibility.Collapsed;
            MessengerInstance.Register<Visibility>(this, "Collapse", ChangeVisibility);
            MessengerInstance.Register<Visibility>(this, "AddBookView", ChangeVisibility);

            MessengerInstance.Register<AbstractItem>(this, GrabItem);

            AddBookCommand = new RelayCommand(AddBook);
        }
        private void AddBook()
        {

            Itemlist.Add(SelectedItem);
            SelectedItem = new Book("Harry Potter - 2", 1, 110, "LoDGlo", ItemGenreType.Fantasy, 2002);
        }


        private void ChangeVisibility(Visibility visibility) => UcVisibility = visibility;
        public enum ItemType
        {
            Book,
            Journal
        }
        private void GrabItem(AbstractItem item)
        {
            SelectedItem = item;
            //SelectedCombo = item;
        }

        private System.Collections.IEnumerable txtAuthor;
        public System.Collections.IEnumerable TxtAuthor { get => txtAuthor; set => Set(ref txtAuthor, value); }
        public IEnumerable<ItemGenreType> CmbGenre { get { return Enum.GetValues(typeof(ItemGenreType)).Cast<ItemGenreType>(); } }//הכנסה של אינם שקיים
        public IEnumerable<MonthType> CmbMonth { get { return Enum.GetValues(typeof(MonthType)).Cast<MonthType>(); } }
        public ItemGenreType Selected { get; set; } //הוא יודע מה תפסתי                                                                                                                           //

    }
}
