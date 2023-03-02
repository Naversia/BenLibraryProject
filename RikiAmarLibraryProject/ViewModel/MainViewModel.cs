using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using BenEliLibraryProject.Views;

namespace BenEliLibraryProject.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
       //public RelayCommand ShowAddBookViewCommand { get; set; }

             public RelayCommand<string> ManageUcVisibilitiesCommand { get; set; }

        private Logic.ItemCollection itemCollection;

        private ObservableCollection<AbstractItem> items;

        public ObservableCollection<AbstractItem> Items { get => items; set => Set(ref items, value); }

        public RelayCommand ShowItemsCommand { get; set; }

        public MainViewModel(Logic.ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            Items = new ObservableCollection<AbstractItem>(itemCollection.GetItems());

            ShowItemsCommand = new RelayCommand(ShowItems);

            ManageUcVisibilitiesCommand = new RelayCommand<string>(param => ManageUcVisibilities(param));
        }

        private void ManageUcVisibilities(string param)
        {
            MessengerInstance.Send(Visibility.Collapsed, "Collapse");
            MessengerInstance.Send(Visibility.Visible, param);
        }
        private void ShowItems()
        {
            Items = new ObservableCollection<AbstractItem>(itemCollection.GetItems());
        }
    }

    

}



