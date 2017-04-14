using Microsoft.VisualStudio.TestTools.UnitTesting;
﻿using System;
using System.Linq;
using SecureNetRestApiSDK.Api.Controllers;
using SecureNetRestApiSDK.Api.Models;
using SecureNetRestApiSDK.Api.Requests;
using SecureNetRestApiSDK.Api.Responses;
using SNET.Core;

namespace SecureNetRestApiSDK_UnitTest.Controllers
{
    [TestClass]
    public class BatchesControllerTests
    {
        #region Settlement

        /// <summary>
        /// Unit Tests for a CloseBatch request and a subsequent RetrieveClosedBatch request. Tests combined in one method to pass the
        /// required batch identifier and guaranteee the order of operation.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#closebatch
        /// </summary>
        [TestMethod]
        public void Settlement_Close_Batch_And_Retrieve_Closed_Batch_Request_Returns_Successfully()
        {
            var batchId = Settlement_Close_Batch_Request_Returns_Successfully();
            Settlement_Retrieve_Closed_Batch_Request_Returns_Successfully(batchId);
        }

        /// <summary>
        /// Successful response returned from a Settlement Close Batch request.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#closebatch
        /// </summary>
        public int Settlement_Close_Batch_Request_Returns_Successfully()
        {
            // Arrange
            CreateATransaction();
            var request = Helper.GetABatchCloseRequest();
            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchCloseResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            return int.Parse(response.BatchId);
        }

        /// <summary>
        /// Successful response returned from a Settlement Retrieve Closed Batch request.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#retrievebatch
        /// </summary>
        public void Settlement_Retrieve_Closed_Batch_Request_Returns_Successfully(int batchId)
        {
            // Arrange
            var request = new BatchRetrieveRequest
            {
                Id = batchId
            };
            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchRetrieveResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Settlement Retrieve Current Batch request.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#currentbatch
        /// </summary>
        [TestMethod]
        public void Settlement_Retrieving_Current_Batch_Request_Returns_Successfully()
        {
            // Arrange
            var request = new BatchCurrentRequest();
            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchCurrentResponse>(apiContext, request);
           
            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Unit Tests for an CloseBatch request and a subsequent RetrieveClosedBatch request with PosCardholderActivatedTerminal. Tests combined in one method to pass the
        /// required batch identifier and guaranteee the order of operation.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#closebatch
        /// </summary>
        [TestMethod]
        public void Settlement_Close_Batch_And_Retrieve_Closed_Batch_Request_With_CATIndicator_Returns_Successfully()
        {
            var transactionId = CreateATransaction();
            var batchId = Settlement_Close_Batch_Request_With_CATIndicator_Returns_Successfully(transactionId);
            Settlement_Retrieve_Closed_Batch_Request_With_CATIndicator_Returns_Successfully(batchId, transactionId);
        } 

        /// <summary>
        /// Successful response returned from a Settlement Close Batch request with PosCardholderActivatedTerminal.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#closebatch
        /// </summary>
        public int Settlement_Close_Batch_Request_With_CATIndicator_Returns_Successfully(int transactionId)
        {
            // Arrange
            var request = Helper.GetABatchCloseRequest();

            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchCloseResponse>(apiContext, request);
            var transaction = response.Transactions.First(x => x.TransactionId == transactionId);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(transaction.CATIndicator, Helper.GetCATIndicatorValue());
            Assert.IsTrue(response.Success);
            return int.Parse(response.BatchId);
        }

        /// <summary>
        /// Successful response returned from a Settlement Retrieve Closed Batch request with PosCardholderActivatedTerminal.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#retrievebatch
        /// </summary>
        public void Settlement_Retrieve_Closed_Batch_Request_With_CATIndicator_Returns_Successfully(int batchId, int transactionId)
        {
            // Arrange
            var request = new BatchRetrieveRequest
            {
                Id = batchId
            };
            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchRetrieveResponse>(apiContext, request);
            var transaction = response.Transactions.First(x => x.TransactionId == transactionId);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(transaction.CATIndicator, Helper.GetCATIndicatorValue());
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Settlement Retrieve Current Batch request with PosCardholderActivatedTerminal.
        /// https://apidocs.securenet.com/docs/settlement.html?lang=csharp#currentbatch
        /// </summary>
        [TestMethod]
        public void Settlement_Retrieving_Current_Batch_Request_With_CATIndicator_Returns_Successfully()
        {
            // Arrange
            var request = new BatchCurrentRequest();
            var apiContext = new APIContext();
            var controller = new BatchesController();

            // Act
            var response = controller.ProcessRequest<BatchCurrentResponse>(apiContext, request);
            
            // Assert
            Assert.IsNotNull(response);
            response.Transactions.ForEach(t => Assert.AreEqual(t.CATIndicator, Helper.GetCATIndicatorValue()));
            Assert.IsTrue(response.Success);
        }

        public int CreateATransaction()
        {
            var request = Helper.GetAChargeRequest();
            
            request.ExtendedInformation.AdditionalTerminalInfo = new AdditionalTerminalInfo { CATIndicator = Helper.GetCATIndicatorValue() };

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
