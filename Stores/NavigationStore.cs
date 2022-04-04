using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView 
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnCurrentViewModelChanged();
            } 
        }

        public event Action CurrentViewModelChanged;

        public void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
