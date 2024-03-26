using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;
using ToWatchList.Interfaces;
using static System.Net.WebRequestMethods;

namespace ToWatchList.Data
{
    public class TMDBService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://api.themoviedb.org/3";
        private readonly string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJhMWYyZTM1ZDQzMWEyMTE2ODEzMTJiNjY1NzI2NmU2MyIsInN1YiI6IjYzYzViMWFlYWQ1OWI1MDIzZjBiNzFhNiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TfONESfB6lWe0jNmSjuJwrebQ7_c5VlIO_FgMbZdva4";

        public async Task<ApiResponse> SearchMulti(string query)
        {
            var jsonString = await GetTMDBResponseAsync($"/search/multi?include_adult=false&query={query}&language=en-US");
            ApiResponse searchResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
            return searchResponse;
        }

        public async Task<string> GetTMDBResponseAsync(string path)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseUrl + path)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

    }
}
