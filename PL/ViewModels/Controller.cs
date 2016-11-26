using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace PL.ViewModels
{
    public class Controller : BaseViewModel
    {
        private static int _currentScreen = 1;
        public IBL bl_adapter;
        private BaseViewModel _viewModel;
        public BaseViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                OnPropertyChanged("ViewModel");
            }
        }
        public Controller()
        {
            bl_adapter = BL_imp.Insatnce;
            ViewModel = new MainViewViewModel(bl_adapter);
            Nav1To2 = new DelegateCommand(MainViewToBookDetails);
        }

        private DelegateCommand _nav1To2;
        public DelegateCommand Nav1To2
        {
            get { return _nav1To2; }
            set
            {
                _nav1To2 = value;
                OnPropertyChanged("Nav1To2");
            }
        }

        public void MainViewToBookDetails(object obj)
        {
            if (_currentScreen != 1)
                return;
            var mainView = ViewModel as MainViewViewModel;
            if (mainView.SelectedBook == null)
                return;
            var book = mainView.SelectedBook;
            ViewModel = new BookDetailsViewModel();
            var bookDetails = ViewModel as BookDetailsViewModel;
            bookDetails.SelectedBook = book;
            _currentScreen = 2;
        }
    }
}
