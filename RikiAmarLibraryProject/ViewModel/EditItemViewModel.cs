using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BenEliLibraryProject.ViewModel
{
    public class EditItemViewModel : ViewModelBase
    {
        private Visibility ucVisibility;
        public Visibility UcVisibility { get => ucVisibility; set => Set(ref ucVisibility, value); } //{get => field; set => value}
        public RelayCommand DeleteCommand { get; set; } 

        public ItemCollection Item { get;  set; }
        public ObservableCollection<AbstractItem> Itemlist { get; set; }


        private ItemGenreType selectedCombo;
        public ItemGenreType SelectedCombo 
        { 
            get => selectedCombo;
            set
            {
                value = selectedCombo;
                selectedItem.Genre = value;
            }
        } 
        public IEnumerable<ItemGenreType> CmbGenre { get { return Enum.GetValues(typeof(ItemGenreType)).Cast<ItemGenreType>(); }  }


        private AbstractItem selectedItem;
        public AbstractItem SelectedItem { get => selectedItem; set => Set(ref selectedItem, value); }

        public EditItemViewModel(ItemCollection item)
        {
            Item = item;
            Itemlist = item.ItemsList;

            UcVisibility = Visibility.Collapsed;
            MessengerInstance.Register<Visibility>(this, "Collapse", ChangeVisibility);
            MessengerInstance.Register<Visibility>(this, "EditView", ChangeVisibility);

            MessengerInstance.Register<Visibility>(this, "Token", ChangeVisibility);

            MessengerInstance.Register<AbstractItem>(this, GrabItem);

            DeleteCommand = new RelayCommand(RemoveItem);
        }

        private void RemoveItem()
        {
            Itemlist.Remove(SelectedItem);  
        }

        private void ChangeVisibility(Visibility visibility) => UcVisibility = visibility;
        
       
    

        //public ItemCollection ItemCollection1 => itemCollection;

        private void GrabItem(AbstractItem item)
        {
            SelectedItem = item;
            //SelectedCombo = item;       
        }
    }
}
