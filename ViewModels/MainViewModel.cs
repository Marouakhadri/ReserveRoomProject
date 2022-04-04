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

        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentView => _navigationStore.CurrentView;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
