﻿using System.Net.Http.Headers;
using Newtonsoft.Json;
using ToWatchList.Data.Model;

namespace ToWatchList.Data
{
    public class TMDBService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://api.themoviedb.org/3";
        private readonly string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJhMWYyZTM1ZDQzMWEyMTE2ODEzMTJiNjY1NzI2NmU2MyIsInN1YiI6IjYzYzViMWFlYWQ1OWI1MDIzZjBiNzFhNiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TfONESfB6lWe0jNmSjuJwrebQ7_c5VlIO_FgMbZdva4";

        /// <summary>
        /// Return a list of media based on the query text
        /// </summary>
        /// <param name="query">User query text</param>
        /// <returns>List of media, inside ApiResponse</returns>
        public async Task<ApiResponse> SearchMulti(string query)
        {
            var jsonString = await GetTMDBResponseAsync($"/search/multi?include_adult=false&query={query}&language=en-US");
            ApiResponse searchResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
            return searchResponse;
        }

        /// <summary>
        /// Helper class, can be use for all other TMDB API calls
        /// </summary>
        /// <param name="path">The api endpoint</param>
        /// <returns>json response</returns>
        private async Task<string> GetTMDBResponseAsync(string path)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseUrl + path)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }


        //public async Task<MediaItem> GetDetailByIDAsync(string id)
        //{
        //    var jsonString = await GetTMDBResponseAsync($"/movie/{id}");
        //    MediaItem item = JsonConvert.DeserializeObject<MediaItem>(jsonString);
        //    return item;
        //}
    }
}
