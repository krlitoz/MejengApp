using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MejengApp.Servicios
{
    public class ApiRest
    {
        public const string SERVICE_ENDPOINT = "http://api.football-data.org/v1/";

        public async Task<string> GetJsonAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Debug.WriteLine("Sin conexion");
                return string.Empty;
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SERVICE_ENDPOINT);
                client.DefaultRequestHeaders.Add("X-Auth-Token", "4227a041ed114d22aafd4377d91e578e");
                //client.DefaultRequestHeaders.Accept = ...

                var json = await client.GetStringAsync($"competitions/?season=2017");

                Debug.WriteLine(json);

                return json;
            }
        }

        public async Task<string> GetJsonAsync(string uri)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Debug.WriteLine("Sin conexion");
                return string.Empty;
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SERVICE_ENDPOINT);
                client.DefaultRequestHeaders.Add("X-Auth-Token", "4227a041ed114d22aafd4377d91e578e");
                //client.DefaultRequestHeaders.Accept = ...

                var json = await client.GetStringAsync(new Uri(uri));

                Debug.WriteLine(json);

                return json;
            }
        }

    }
}
