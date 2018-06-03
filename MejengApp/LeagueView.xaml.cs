using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using MejengApp.Servicios;
using MejengApp.Models;

using Xamarin.Forms;

namespace MejengApp
{
    public partial class LeagueView 
    {
        ApiRest apiClient { get; set; }
        public ObservableCollection<Team> Data { get; set; }

        string mUri = "";

        public LeagueView(string uri, ApiRest client)
        {
            InitializeComponent();

            apiClient = client;

            BindingContext = this;

            mUri = uri;

            Data = new ObservableCollection<Team>();

            teamsDataList.ItemsSource = Data;

            loadTeams();
        }

        protected async void loadTeams()
        {
            //base.OnAppearing();

            //IsBusy = true;

            try
            {
                var json = await apiClient.GetJsonAsync(mUri);

                var leagueTeams = JsonConvert.DeserializeObject<Teams>(json);

                teamsDataList.ItemsSource = leagueTeams.teams;

            }
            finally
            {
                //IsBusy = false;
            }

        }

        private async void onItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Team;

            // LeagueView leagueView = new LeagueView($"/v1/competitions/{item.id}/teams");
                await Navigation.PushAsync(new TeamDetail($"{item._links["fixtures"]["href"]}" , item.name, apiClient));
        }

    }
}
