using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureNetRestApiSDK.Api.Controllers;
using SecureNetRestApiSDK.Api.Models;
using SecureNetRestApiSDK.Api.Requests;
using SecureNetRestApiSDK.Api.Responses;
using SNET.Core;

namespace SecureNetRestApiSDK_UnitTest.Controllers
{
    [TestClass]
    public class AccountsControllerTests
    {
        #region Ebt Inquiry balance
        /*
        /// <summary>
        /// Successful response returned from a EBT Card Present Inquiry balance request.
        /// </summary>
        [TestMethod]
        public void Ebt_Card_Present_InquiryBalance_Request_Returns_Successfully()
        {
            // Arrange
            var request = new InquiryRequest
            {
                Card = new Card
                {
                    TrackData = ";5081480000001235=20121000000112345678?",
                    PinBlock = "B50CBCC24FC053EC",
                    Ksn = "10002000090002A00039"
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
                ExtendedInformation = new ExtendedInformation
                {
                    EbtData = new Ebt
                    {
                        EbtType = "EBTFOODSTAMPBALANCE",
                        FnsNumber = "1234567"
                    }
                }
            };

            var apiContext = new APIContext();
            var controller = new AccountsController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }
        */
        #endregion
    }
}
