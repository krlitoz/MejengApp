using System;
using System.Collections.Generic;
using MejengApp.Models;
using MejengApp.Servicios;
using Newtonsoft.Json;
using Xamarin.Forms;
using FFImageLoading.Svg.Forms;
using System.Collections.ObjectModel;

namespace MejengApp
{
    public partial class TeamDetail : ContentPage
    {
        ApiRest apiClient { get; set; }
        string mTeamName { get; set; }
        public ObservableCollection<Fixture> Data { get; set; }

        public TeamDetail(string uri, string teamName,ApiRest client)
        {
            InitializeComponent();
            Data = new ObservableCollection<Fixture>();
            apiClient = client;
            mTeamName = teamName;

            loadTeamDetail(uri);
        }

        public async void loadTeamDetail(String uri)
        {
            
            var json = await apiClient.GetJsonAsync(uri);

            var fixtures = JsonConvert.DeserializeObject<Fixtures>(json);

            //teamLogo.Source = ImageSource.FromUri(new Uri(team.crestUrl));
            //name.Text = mTeamName + " Fixtures";


            //ListViewFixtures.ItemsSource = fixtures.fixtures;
            //ListViewResults.ItemsSource = fixtures.fixtures[0].result;
            foreach (Fixture item in fixtures.fixtures)
            {
                Data.Add(new Fixture(item.matchday, item.homeTeamName, item.awayTeamName, item.date.Substring(0,10), item.result["goalsHomeTeam"].ToString(),
                                     item.result["goalsAwayTeam"].ToString()));
            }
            ListViewFixtures.ItemsSource = Data;
        }


        public string concatenateInfo(Fixture item)
        {
            string info = item.matchday.ToString() + item.homeTeamName;


            return info;
        }
    }
}
