using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SecureNetRestApiSDK.Api.Models
{
    public class StoredInstallmentPaymentPlan
    {
        #region Properties
        [JsonProperty("softDescriptor")]
        public string SoftDescriptor { get; set; }
        [JsonProperty("dynamicMCC")]
        public string DynamicMCC { get; set; }

        #endregion
    }
}
