using System;
using Newtonsoft.Json;

namespace SecureNetRestApiSDK.Api.Models
{
    public class StoredScheduledVariablePaymentPlan
    {
        #region Properties

        [JsonProperty("scheduleId")]
        public int ScheduleId { get; set; }

        [JsonProperty("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("softDescriptor")]
        public string SoftDescriptor { get; set; }

        #endregion
    }
}
