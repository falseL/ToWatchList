using Newtonsoft.Json;

namespace ToWatchList.Data
{
    public class MediaItem
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { set { Name = value; } }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("genre_ids")]
        public int[] GenreIds { get; set; }

        [JsonProperty("popularity")]
        public float Popularity { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { set { FirstAirDate = value; } }

        [JsonProperty("vote_average")]
        public float VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("origin_country")]
        public string[] OriginCountry { get; set; }

        public string TruncatedOverview
        {
            get
            {
                if (string.IsNullOrEmpty(Overview))
                    return Overview;

                return Overview.Length <= 200 ? Overview : Overview.Substring(0, 200) + "...";
            }
        }
        public string PosterPathFull
        {
            get
            {
                return $"https://image.tmdb.org/t/p/w342/{PosterPath}";
            }
        }

    }
}

