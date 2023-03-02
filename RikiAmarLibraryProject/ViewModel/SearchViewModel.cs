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
using System.Windows.Input;

namespace BenEliLibraryProject.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private Visibility ucVisibility;
        public Visibility UcVisibility { get => ucVisibility; set => Set(ref ucVisibility, value); }
        public IEnumerable<ItemType> Types { get { return Enum.GetValues(typeof(ItemType)).Cast<ItemType>(); } }

        private Visibility editItemVisibility;//?
        public Visibility EditItemVisibility { get => editItemVisibility; set => Set(ref editItemVisibility, value); }//?

        public RelayCommand OpenEditItemViewCommand { get; set; }

        public RelayCommand SearchTitleCommand { get; set; }
        public RelayCommand SearchPriceCommand { get; set; }
        public RelayCommand SearchAuthorCommand { get; set; }

        public string Title { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }


        public ItemCollection Item { get; set; }

        private ObservableCollection<AbstractItem> itemlist;
        public ObservableCollection<AbstractItem> Itemlist { get => itemlist; set => Set(ref itemlist , value); }


        private AbstractItem selectedItem;

        public AbstractItem SelectedItem { get => selectedItem; set => Set(ref selectedItem, value); }

        public SearchViewModel(ItemCollection item)
        {
            Item = item;
            OpenEditItemViewCommand = new RelayCommand(OpenEditItemView);

            SearchAuthorCommand = new RelayCommand(SearchAuthor);
            SearchPriceCommand = new RelayCommand(SearchPrice);
            SearchTitleCommand = new RelayCommand(SearchTitle);

            Itemlist = item.ItemsList;

            UcVisibility = Visibility.Collapsed;
            MessengerInstance.Register<Visibility>(this, "Collapse", ChangeVisibility);
            MessengerInstance.Register<Visibility>(this, "SearchView", ChangeVisibility);
        }

        private void ChangeVisibility(Visibility visibility) => UcVisibility = visibility;
        private void OpenEditItemView() //?
        {
            MessengerInstance.Send(Visibility.Visible, "Token");//דרישה לקבל יוזר קונטרול 
        }
        private void SearchTitle() //?
        {
            Itemlist = Item.ItemsList;
            Itemlist = new ObservableCollection<AbstractItem>(Item.GetByTitle(Itemlist, Title));
        }
        private void SearchPrice() //?
        {
            Itemlist = Item.ItemsList;
            Itemlist = new ObservableCollection<AbstractItem>(Item.GetByPrice(Itemlist,Price));
        }
        private void SearchAuthor() //?
        {
            Itemlist = Item.ItemsList;
            Itemlist = new ObservableCollection<AbstractItem>(Item.GetByPublisher(Itemlist, Author));
        }
        public enum ItemType
        {
            Book,
            Journal
        }
    }
}
