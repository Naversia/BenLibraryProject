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
    public class AddJournalViewModel : ViewModelBase
    {
        private Visibility ucVisibility;
        public Visibility UcVisibility { get => ucVisibility; set => Set(ref ucVisibility, value); }
        public IEnumerable<ItemType> Types { get { return Enum.GetValues(typeof(ItemType)).Cast<ItemType>(); } }

        private AbstractItem selectedItem;
        public AbstractItem SelectedItem { get => selectedItem; set => Set(ref selectedItem, value); }

        public ItemCollection Item { get; set; }
        public ObservableCollection<AbstractItem> Itemlist { get; set; }

        public RelayCommand AddJournalCommand { get; set; }

        public AddJournalViewModel(ItemCollection item)
        {
            Item = item;
            Itemlist = item.ItemsList;
            SelectedItem = new Journal("My First Out", 10, 9.99, "Johny Smithier", ItemGenreType.Thriller, MonthType.Jan);
            UcVisibility = Visibility.Collapsed;
            MessengerInstance.Register<Visibility>(this, "Collapse", ChangeVisibility);
            MessengerInstance.Register<Visibility>(this, "AddJournalView", ChangeVisibility);

            MessengerInstance.Register<AbstractItem>(this, GrabItem);

            AddJournalCommand = new RelayCommand(AddJournal);

        }

        private void AddJournal()
        {
           
            Itemlist.Add(SelectedItem);
            SelectedItem = new Journal("My First Out", 10, 9.99, "Johny Smithier", ItemGenreType.Thriller, MonthType.Jan);
        }

        private void ChangeVisibility(Visibility visibility) => UcVisibility = visibility;
        public IEnumerable<ItemGenreType> CmbGenre { get { return Enum.GetValues(typeof(ItemGenreType)).Cast<ItemGenreType>(); } }//הכנסה של אינם שקיים
        public IEnumerable<MonthType> CmbMonth { get { return Enum.GetValues(typeof(MonthType)).Cast<MonthType>(); } }
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
    }
}
