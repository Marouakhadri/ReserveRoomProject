using ReserveRoom.Models;
using ReserveRoom.Stores;
using ReserveRoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReserveRoom
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            // commit B
            this._hotel = new Hotel("Maroua's Hotel");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentView = new ReservationListingViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private  ReservationListingViewModel reservationListingView()
        {
            _navigationStore.CurrentView = new ReservationListingViewModel(NavigationStore navigationStore);
        }
    }
}
