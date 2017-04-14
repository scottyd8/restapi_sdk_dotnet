using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureNetRestApiSDK.Api.Controllers;
using SecureNetRestApiSDK.Api.Models;
using SecureNetRestApiSDK.Api.Requests;
using SecureNetRestApiSDK.Api.Responses;
using SNET.Core;

namespace SecureNetRestApiSDK_UnitTest.Controllers
{
    [TestClass]
    public class TransactionsControllerTests
    {
        #region Transaction Reporting And Management

        /// <summary>
        /// Successful response returned from a Search Transaction request.
        /// https://apidocs.securenet.com/docs/transactions.html?lang=csharp#search
        /// </summary>
        [TestMethod]
        public void Transaction_Reporting_And_Management_Search_Transaction_Request_Returns_Successfully()
        {
            // Arramge
            var containCATIndicator = false;
            var request = Helper.GetAnTransactionSearchRequest();
            request.TransactionId = CreateATransaction(containCATIndicator);

            var apiContext = new APIContext();
            var controller = new TransactionsController();

            // Act
            var response = controller.ProcessRequest<TransactionSearchResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Retrieve Transaction request.
        /// https://apidocs.securenet.com/docs/transactions.html?lang=csharp#retrieve
        /// </summary>
        [TestMethod]
        public void Transaction_Reporting_And_Management_Retrieve_Transaction_Request_Returns_Successfully()
        {
            // Arrange
            var containCATIndicator = false;
            var request = new TransactionRetrieveRequest {TransactionId = CreateATransaction(containCATIndicator)};

            var apiContext = new APIContext();
            var controller = new TransactionsController();

            // Act
            var response = controller.ProcessRequest<TransactionRetrieveResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from an Update Transaction request.
        /// https://apidocs.securenet.com/docs/transactions.html?lang=csharp#update
        /// </summary>
        [TestMethod]
        public void Transaction_Reporting_And_Management_Update_Transaction_Request_Returns_Successfully()
        {
            // Arrange
            var containCATIndicator = false;
            var request = Helper.GetAnTransactionUpdateRequest();
            request.ReferenceTransactionId = CreateATransaction(containCATIndicator);

            var apiContext = new APIContext();
            var controller = new TransactionsController();

            // Act
            var response = controller.ProcessRequest<TransactionUpdateResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Search Transaction request withCATIndicator.
        /// https://apidocs.securenet.com/docs/transactions.html?lang=csharp#search
        /// </summary>
        [TestMethod]
        public void Transaction_Reporting_And_Management_Search_Transaction_Request_With_CATIndicator_Returns_Successfully()
        {
            // Arramge
            var containCATIndicator = true;
            var request = Helper.GetAnTransactionSearchRequest();
            request.TransactionId = CreateATransaction(containCATIndicator);

            var apiContext = new APIContext();
            var controller = new TransactionsController();

            // Act
            var response = controller.ProcessRequest<TransactionSearchResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            response.Transactions.ForEach(t => Assert.AreEqual(t.CATIndicator, Helper.GetCATIndicatorValue()));
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Retrieve Transaction request.
        /// https://apidocs.securenet.com/docs/transactions.html?lang=csharp#retrieve
        /// </summary>
        [TestMethod]
        public void Transaction_Reporting_And_Management_Retrieve_Transaction_Request_With_CATIndicato_Returns_Successfully()
        {
            // Arrange
            var containCATIndicator = true;
            var request = new TransactionRetrieveRequest
            {
                TransactionId = CreateATransaction(containCATIndicator)
             };

            var apiContext = new APIContext();
            var controller = new TransactionsController();

            // Act
            var response = controller.ProcessRequest<TransactionRetrieveResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            response.Transactions.ForEach(t => Assert.AreEqual(t.CATIndicator, Helper.GetCATIndicatorValue()));
            Assert.IsTrue(response.Success);
        }

        public int CreateATransaction(bool containCATIndicator)
        {
            var request = Helper.GetAChargeRequest();
           
            if(containCATIndicator)
            request.ExtendedInformation.AdditionalTerminalInfo = new AdditionalTerminalInfo{CATIndicator = Helper.GetCATIndicatorValue() };

            var apiContext = new APIContext();
            var controller = new PaymentsController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            return response.Transaction.TransactionId;
        }

        #endregion
    }
}
