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
        }
    }
}
