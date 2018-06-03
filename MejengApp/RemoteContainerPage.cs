using MejengApp.Models;
using MejengApp.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MejengApp
{
    public class RemoteContainerPage : ContainerPage
    {
        public RemoteContainerPage()
        {
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;

            try
            {
                var json = await apiClient.GetJsonAsync();

                var competitions = JsonConvert.DeserializeObject<Competition[]>(json);

                CompetitionsList.Data.Clear();

                foreach (var item in competitions)
                {
                    CompetitionsList.Data.Add(item);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

