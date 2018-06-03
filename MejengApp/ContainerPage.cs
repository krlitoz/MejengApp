using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MejengApp.Servicios;
using Xamarin.Forms;

namespace MejengApp
{
    public class ContainerPage : ContentPage
    {
        protected CompetitionsView CompetitionsList { get; set; }
        public LeagueView TeamsList { get; set; }
        public ApiRest apiClient { get; set; }

        public ContainerPage()
        {
            Title = "Listado de datos";

            apiClient = new ApiRest();

            CompetitionsList = new CompetitionsView(apiClient);
            Content = CompetitionsList;

        }
    }
}

