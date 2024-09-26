using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectPractice.API.Model
{
    public class BreedData
    {
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("first_page_url")]
        public Uri FirstPageUrl { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("last_page")]
        public long LastPage { get; set; }

        [JsonProperty("last_page_url")]
        public Uri LastPageUrl { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("next_page_url")]
        public Uri NextPageUrl { get; set; }

        [JsonProperty("path")]
        public Uri Path { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("prev_page_url")]
        public object PrevPageUrl { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("breed")]
        public string Breed { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("coat")]
        public string Coat { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }


}