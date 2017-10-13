using Newtonsoft.Json;
using SecureNetRestApiSDK.Api.Models;

namespace SecureNetRestApiSDK.Api.Responses
{
    public class InquiryResponse : SecureNetResponse
    {
        #region Properties

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        #endregion
    }
}
