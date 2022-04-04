using ReserveRoom.Models;
using ReserveRoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
       public ViewModelBase CurrentView => _navigationStore.CurrentView;

        //public NormalClass normalClass { get; }
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
