using Newtonsoft.Json;
using System;

namespace web.GurselFramework.Business.HttpService.Concrete.Models
{
    [Serializable]
    public struct TokenModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_Description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}
