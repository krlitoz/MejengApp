using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using MejengApp.Models;
using MejengApp.Servicios;

namespace MejengApp
{
    public partial class CompetitionsView
    {

        public ObservableCollection<Competition> Data { get; set; }
        public Command RefreshCommand { get; set; }
        public ApiRest mClient;

        public CompetitionsView(ApiRest client)
        {
            InitializeComponent();
            BindingContext = this;
            mClient = client;
            Data = new ObservableCollection<Competition>();

            compDataList.ItemsSource = Data;
        }

        private async void onItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Competition;
            await Navigation.PushAsync(new LeagueView($"/v1/competitions/{item.id}/teams", mClient));
        }

    }
}
