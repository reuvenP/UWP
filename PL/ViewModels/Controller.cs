using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Collections.ObjectModel;
using BE;
using System.Windows;

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
            Nav2Back = new DelegateCommand(BookDetailsBack);
            Cart = new ObservableCollection<Book>();
            AddToCartCMD = new DelegateCommand(AddToCart);
        }

        private DelegateCommand _addToCartCMD;
        public DelegateCommand AddToCartCMD
        {
            get
            {
                return _addToCartCMD;
            }

            set
            {
                _addToCartCMD = value;
                OnPropertyChanged("AddToCartCMD");
            }
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

        private DelegateCommand _nav2Back;
        public DelegateCommand Nav2Back
        {
            get
            {
                return _nav2Back;
            }

            set
            {
                _nav2Back = value;
                OnPropertyChanged("Nav2Back");
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

        public void BookDetailsBack(object obj)
        {
            if (_currentScreen != 2)
                return;
            ViewModel = new MainViewViewModel(bl_adapter);
            _currentScreen = 1;
        }

        private ObservableCollection<Book> _cart;
        public ObservableCollection<Book> Cart
        {
            get
            {
                return _cart;
            }

            set
            {
                _cart = value;
                OnPropertyChanged("Cart");
            }
        }

        public void AddToCart(object obj)
        {
            if (_currentScreen != 2)
                return;
            var bookDetailsView = ViewModel as BookDetailsViewModel;
            var book = bookDetailsView.SelectedBook;
            Cart.Add(book);
            MessageBox.Show("Book " + book.Title + " Was Added!");
        }
    }
}
