using SecureNetRestApiSDK.Api.Models;
using SNET.Core;

namespace SecureNetRestApiSDK.Api.Requests
{
    /// <summary>
    /// Request class used for issuing a transaction.
    /// </summary>
    public class VerifyRequest : SecureNetRequest
    {
        #region Properties

        /// <summary>
        /// Amount to charge the account.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Credit-card-specific data. Required for credit card charges.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Contains developer Id and version information related to the integration.
        /// </summary>
        public DeveloperApplication DeveloperApplication { get; set; }

        /// <summary>
        /// Additional data to assist in reporting, ecommerce or moto transactions, and level 2 or level 3 processing. Includes user-defined fields and invoice-related information.
        /// </summary>
        public ExtendedInformation ExtendedInformation { get; set; }

        #endregion

        #region Methods

        public override string GetUri()
        {
            return "api/Payments/Verify";
        }

        public override HttpMethodEnum GetMethod()
        {
            return HttpMethodEnum.POST;
        }

        #endregion
    }
}
