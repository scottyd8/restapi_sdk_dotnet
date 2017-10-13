using SecureNetRestApiSDK.Api.Models;
using SNET.Core;

namespace SecureNetRestApiSDK.Api.Requests
{
    /// <summary>
    /// Request class used for authorizing a transaction.
    /// </summary>
    public class InquiryRequest : SecureNetRequest
    {
        #region Properties

        /// <summary>
        /// Credit-card-specific data. In the case of a card-present transaction, track data from a swiped transaction is the most commonly used property. Required for credit card charges.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Encryption mode for the transaction. Required when using device-based encryption.
        /// </summary>
        public Encryption Encryption { get; set; }

        /// <summary>
        /// Additional data to assist in reporting, ecommerce or moto transactions, and level 2 or level 3 processing. Includes user-defined fields and invoice-related information.
        /// </summary>
        public ExtendedInformation ExtendedInformation { get; set; }

        /// <summary>
        /// Contains developer Id and version information related to the integration.
        /// </summary>
        public DeveloperApplication DeveloperApplication { get; set; }

        #endregion

        #region Methods

        public override string GetUri()
        {
            return "api/Accounts/Inquiry";
        }

        public override HttpMethodEnum GetMethod()
        {
            return HttpMethodEnum.POST;
        }

        #endregion
    }
}
