using System;
using Newtonsoft.Json;

namespace SecureNetRestApiSDK.Api.Models
{
    /// <summary>
    /// Contains EBT details.
    /// </summary>
    public class Ebt
    {
        #region Properties
        
        /// <summary>
        /// FNS number for merchant.
        /// </summary>
        [JsonProperty("fnsNumber")]
        public string FnsNumber { get; set; }

        /// <summary>
        /// Ebt indicator associated with the transaction eg. EBTCASHSALE
        /// </summary>
        [JsonProperty("ebtType")]
        public string EbtType { get; set; }

        /// <summary>
        /// Ebt voucher number issued by merchant.
        /// </summary>
        [JsonProperty("voucherNumber")]
        public string VoucherNumber { get; set; }

       #endregion
    }
}
