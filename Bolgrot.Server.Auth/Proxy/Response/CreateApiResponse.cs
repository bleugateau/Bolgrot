using System;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Proxy.Response
{
    public class CreateApiResponse
    {
        [JsonProperty("key")] 
        public string Key { get; set; }

        [JsonProperty("account_id")] 
        public long AccountId { get; set; }

        [JsonProperty("ip")] 
        public string Ip { get; set; }

        [JsonProperty("added_date")] 
        public DateTimeOffset AddedDate { get; set; }

        [JsonProperty("meta")] 
        public object[] Meta { get; set; }

        [JsonProperty("data")] 
        public CreateApiResponseData Data { get; set; }

        [JsonProperty("access")] 
        public object[] Access { get; set; }

        [JsonProperty("refresh_token")] 
        public string RefreshToken { get; set; }

        [JsonProperty("expiration_date")] 
        public DateTimeOffset ExpirationDate { get; set; }
    }

    public partial class CreateApiResponseData
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public partial class CreateApiResponseFailed
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}