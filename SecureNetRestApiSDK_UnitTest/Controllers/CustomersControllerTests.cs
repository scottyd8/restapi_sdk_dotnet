﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureNetRestApiSDK.Api.Controllers;
using SecureNetRestApiSDK.Api.Models;
using SecureNetRestApiSDK.Api.Requests;
using SecureNetRestApiSDK.Api.Responses;
using SNET.Core;

namespace SecureNetRestApiSDK_UnitTest.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        #region SecureNet Vault

        /// <summary>
        /// Unit Tests for Create, Retrieve, Update and Delete Customer requests. Tests combined in one method to pass the
        /// required customer identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Create_Retrieve_Update_And_Delete_Customer_Requests_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Retrieve the Customer
            SecureNet_Vault_Retrieve_Customer_Request_Returns_Successfully(customerId);

            // Update the Customer
            SecureNet_Vault_Update_Customer_Request_Returns_Successfully(customerId);

            // Delete the Customer
            //TODO
        }

        /// <summary>
        /// Successful response returned from a Create Customer request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#createcustomer
        /// </summary>
        public string SecureNet_Vault_Create_Customer_Request_Returns_Successfully()
        {
            // Arrange
            var request = new CreateCustomerRequest
            {
                FirstName = "Jack",
                LastName = "Test",
                PhoneNumber = "512-122-1211",
                EmailAddress = "Some@Emailaddress.Com",
                SendEmailReceipts = true,
                Notes = "test notes",
                Address = new Address
                {
                    Line1 = "123 Main St.",
                    City = "Austin",
                    State = "TX",
                    Zip = "78759"
                },
                Company = "Test Company",
                UserDefinedFields = new List<UserDefinedField>
                {
                    new UserDefinedField
                    {
                        UdfName = "Udf1",
                        UdfValue = "Udf1_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf2",
                        UdfValue = "Udf2_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf3",
                        UdfValue = "Udf3_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf4",
                        UdfValue = "Udf4_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf5",
                        UdfValue = "Udf5_Value"
                    },
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<CreateCustomerResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.CustomerId);
            Assert.IsTrue(response.CustomerId.Length > 0);

            return response.CustomerId;
        }

        /// <summary>
        /// Successful response returned from a Retrieve Customer request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#retrievecustomer
        /// </summary>
        public void SecureNet_Vault_Retrieve_Customer_Request_Returns_Successfully(string customerId)
        {
            // Arrange
            var request = new RetrieveCustomerRequest
            {
                CustomerId = customerId
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<RetrieveCustomerResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from an Update Customer request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#updatecustomer
        /// </summary>
        public void SecureNet_Vault_Update_Customer_Request_Returns_Successfully(string customerId)
        {
            // Arrange
            var request = new UpdateCustomerRequest
            {
                CustomerId = customerId,
                FirstName = "Updated_Name",
                LastName = "QA",
                PhoneNumber = "512-111-1111",
                EmailAddress = "Some@Emailaddress.com",
                SendEmailReceipts = true,
                Notes = "test notes",
                Address = new Address
                {
                    Line1 = "123 Main St.",
                    City = "Austin",
                    State = "TX",
                    Zip = "78759"
                },
                Company = "Test Company Update",
                UserDefinedFields = new List<UserDefinedField>
                {
                    new UserDefinedField
                    {
                        UdfName = "Udf1",
                        UdfValue = "Udf1_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf2",
                        UdfValue = "Udf2_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf3",
                        UdfValue = "Udf3_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf4",
                        UdfValue = "Udf4_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf5",
                        UdfValue = "Udf5_Value"
                    }
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<UpdateCustomerResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Unit Tests for Create, Retrieve, Charge, Update and Delete Payment Account requests. Tests combined in one method to pass the
        /// required payment method identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Create_Retrieve_Charge_Update_And_Delete_Payment_Account_Requests_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Create the Payment Account
            string paymentMethodId = SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(customerId);

            // Retrieve the Payment Account
            SecureNet_Vault_Retrieve_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Pay using a Stored Vault Account
            SecureNet_Vault_Pay_With_Stored_Vault_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Update the Payment Account
            SecureNet_Vault_Update_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Payment Account
            SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Customer
            //TODO
        }

        /// <summary>
        /// Successful response returned from a Create Payment Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#createaccount
        /// </summary>
        public string SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(string customerId)
        {
            // Arrange
            var request = new AddPaymentMethodRequest
            {
                CustomerId = customerId,
                Card = new Card
                {
                    Number = "4444 3333 2222 1111",
                    ExpirationDate = "04/2017",
                    Address = new Address
                    {
                        Line1 = "123 Main St.",
                        City = "Austin",
                        State = "TX",
                        Zip = "78759"
                    },
                    FirstName = "Jack",
                    LastName = "Test"
                },
                Phone = "512-250-7865",
                Notes = "Create A Vault Account",
                AccountDuplicateCheckIndicator = 0,
                Primary = true,
                UserDefinedFields = new List<UserDefinedField>
                {
                    new UserDefinedField
                    {
                        UdfName = "Udf1",
                        UdfValue = "Udf1_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf2",
                        UdfValue = "Udf2_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf3",
                        UdfValue = "Udf3_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf4",
                        UdfValue = "Udf4_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf5",
                        UdfValue = "Udf5_Value"
                    }
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<AddPaymentMethodResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.VaultPaymentMethod);
            Assert.IsNotNull(response.VaultPaymentMethod.PaymentId);

            return response.VaultPaymentMethod.PaymentId;
        }

        /// <summary>
        /// Successful response returned from a Retrieve Payment Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#retrieveaccount
        /// </summary>
        public void SecureNet_Vault_Retrieve_Payment_Account_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new RetrievePaymentAccountRequest
            {
                CustomerId = customerId,
                PaymentMethodId = paymentMethodId
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<RetrievePaymentAccountResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from an Update Payment Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#updateaccount
        /// </summary>
        public void SecureNet_Vault_Update_Payment_Account_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new UpdatePaymentMethodRequest
            {
                CustomerId = customerId,
                PaymentMethodId = paymentMethodId,
                Card = new Card
                {
                    Number = "4444 3333 2222 1111",
                    Cvv = "999",
                    ExpirationDate = "04/2017",
                    Address = new Address
                    {
                        Line1 = "123 Main St.",
                        City = "Austin",
                        State = "TX",
                        Zip = "78759"
                    },
                    FirstName = "Jack",
                    LastName = "Updated"
                },
                Phone = "512-250-7865",
                Notes = "Create a vault account",
                Primary = true,
                UserDefinedFields = new List<UserDefinedField>
                {
                    new UserDefinedField
                    {
                        UdfName = "Udf1",
                        UdfValue = "Udf1_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf2",
                        UdfValue = "Udf2_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf3",
                        UdfValue = "Udf3_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf4",
                        UdfValue = "Udf4_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf5",
                        UdfValue = "Udf5_Value"
                    }
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<UpdatePaymentMethodResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from an Delete Payment Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#removeaccount
        /// </summary>
        public void SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new RemovePaymentMethodRequest
            {
                CustomerId = customerId,
                PaymentMethodId = paymentMethodId,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<RemovePaymentMethodResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from an Create Customer and Payment Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#createcustomerandPayment
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Create_Customer_And_Payment_Account_Request_Returns_Successfully()
        {
            // Arrange
            var request = new VaultCustomerAndPaymentMethodRequest
            {
                FirstName = "Jack",
                LastName = "Test",
                PhoneNumber = "512-250-7865",
                Address = new Address
                {
                    Line1 = "123 Main St.",
                    City = "Austin",
                    State = "TX",
                    Zip = "78759",
                    Country = "US"
                },
                EmailAddress = "Some@Emailaddress.Com",
                SendEmailReceipts = true,
                Company = "Test company",
                Notes = "This is test notes",
                UserDefinedFields = new List<UserDefinedField>
                {
                    new UserDefinedField
                    {
                        UdfName = "Udf1",
                        UdfValue = "Udf1_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf2",
                        UdfValue = "Udf2_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf3",
                        UdfValue = "Udf3_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf4",
                        UdfValue = "Udf4_Value"
                    },
                    new UserDefinedField
                    {
                        UdfName = "Udf5",
                        UdfValue = "Udf5_Value"
                    }
                },
                CustomerDuplicateCheckIndicator = 1,
                Card = new Card
                {
                    Number = "4444 3333 2222 1111",
                    ExpirationDate = "04/2017",
                    FirstName = "Jack",
                    LastName = "Test",
                    Address = new Address
                    {
                        Line1 = "123 Main St.",
                        City = "Austin",
                        State = "TX",
                        Zip = "78749",
                        Country = "US"
                    }
                },
                Phone = "512-250-7865",
                Primary = true,
                AccountDuplicateCheckIndicator = 1,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<VaultCustomerAndPaymentMethodResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Storing Acount After Charge request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#storedaccount
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Store_Account_After_Charge_Request_Returns_Successfully()
        {
            // Arrange
            var request = Helper.GetAChargeRequest();
            
            request.AddToVault = true;

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Pay with Stored Vault Account request.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#payaccount
        /// </summary>
        public void SecureNet_Vault_Pay_With_Stored_Vault_Account_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = Helper.GetAChargeRequest();
            request.PaymentVaultToken = new PaymentVaultToken
            {
                CustomerId = customerId,
                PaymentMethodId = paymentMethodId,
                PaymentType = "CREDIT_CARD"
            };
            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Storing Acount After Charge request, with PosCardholderActivatedTerminal.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#storedaccount
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Store_Account_After_Charge_Request_With_CATIndicator_Returns_Successfully()
        {
            // Arrange
            var request = Helper.GetAChargeRequest();
            
            request.AddToVault = true;
            request.ExtendedInformation.AdditionalTerminalInfo = new AdditionalTerminalInfo
            {
                CATIndicator = Helper.GetCATIndicatorValue()
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Transaction.CATIndicator, Helper.GetCATIndicatorValue());
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Pay with Stored Vault Account request, with PosCardholderActivatedTerminal.
        /// https://apidocs.securenet.com/docs/vault.html?lang=csharp#payaccount
        /// </summary>

        /// <summary>
        /// Unit Tests for Create, Retrieve, Charge, Update and Delete Payment Account requests. Tests combined in one method to pass the
        /// required payment method identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void SecureNet_Vault_Create_Retrieve_Charge_Update_And_Delete_Payment_Account_Requests_Wtih_CATIndicator_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Create the Payment Account
            string paymentMethodId = SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(customerId);

            // Retrieve the Payment Account
            SecureNet_Vault_Retrieve_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Pay using a Stored Vault Account
            SecureNet_Vault_Pay_With_Stored_Vault_Account_Request_With_CATIndicator_Returns_Successfully(customerId, paymentMethodId);

            // Update the Payment Account
            SecureNet_Vault_Update_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Payment Account
            SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Customer
            //TODO
        }

        public void SecureNet_Vault_Pay_With_Stored_Vault_Account_Request_With_CATIndicator_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = Helper.GetAChargeRequest();
            request.PaymentVaultToken = new PaymentVaultToken
            {
                CustomerId = customerId,
                PaymentMethodId = paymentMethodId,
                PaymentType = "CREDIT_CARD"
            };
            request.ExtendedInformation.AdditionalTerminalInfo = new AdditionalTerminalInfo
            {
                CATIndicator = Helper.GetCATIndicatorValue()
            };
            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<ChargeResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Transaction.CATIndicator, Helper.GetCATIndicatorValue());
            Assert.IsTrue(response.Success);
        }
        #endregion

        #region RecurringBilling

        /// <summary>
        /// Unit Tests for Creating a Payment Account, Creating a Recurring Payment Plan, Updating the Recurring Payment Plan, Retrieving the Recurring Payment Plan, and 
        /// deleting the Recurring Payment Plan requests. Tests combined in one method to pass the required payment method identifier, the plan identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void Recurring_Billing_Create_Retrieve_Update_And_Delete_Recurring_Payment_Plan_Requests_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Create the Payment Account
            string paymentMethodId = SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(customerId);

            // Create the Recurring Payment Plan 
            string planId = Recurring_Billing_Create_Recurring_Payment_Plan_Request_Returns_Successfully(customerId, paymentMethodId);

            // Retrieve the Recurring Payment Plan
            Recurring_Billing_Retrieve_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Update the Recurring Payment Plan
            Recurring_Billing_Update_Recurring_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Delete the Recurring Payment Plan
            Recurring_Billing_Delete_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Delete the Payment Account
            SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Customer
            //TODO
        }

        /// <summary>
        /// Successful response returned from a Create Recurring Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#recurring
        /// </summary>
        public string Recurring_Billing_Create_Recurring_Payment_Plan_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new AddRecurringPaymentPlanRequest
            {
                CustomerId = customerId,
                Plan = new RecurringPaymentPlan
                {
                    CycleType = "monthly",
                    DayOfTheMonth = 1,
                    DayOfTheWeek = 1,
                    Month = 6,
                    Frequency = 10,
                    Amount = 22.95m,
                    StartDate = Convert.ToDateTime("10/01/2017"),
                    EndDate = Convert.ToDateTime("10/01/2035"),
                    MaxRetries = 4,
                    PrimaryPaymentMethodId = paymentMethodId,
                    Notes = "This is a recurring plan",
                    Active = true,
                    UserDefinedFields = new List<UserDefinedField>
                    {
                        new UserDefinedField
                        {
                            UdfName = "Udf1",
                            UdfValue = "Udf1_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf2",
                            UdfValue = "Udf2_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf3",
                            UdfValue = "Udf3_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf4",
                            UdfValue = "Udf4_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf5",
                            UdfValue = "Udf5_Value"
                        }
                    },
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<AddRecurringPaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredRecurringPaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredRecurringPaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.PlanId);

            return response.PlanId;
        }

        /// <summary>
        /// Successful response returned from an Update Recurring Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#updaterecurring
        /// </summary>
        public void Recurring_Billing_Update_Recurring_Payment_Plan_Request_Returns_Successfully(string customerId, string planId)
        {
            // Arrange
            var request = new UpdateRecurringPaymentPlanRequest
            {
                CustomerId = customerId,
                PlanId = planId,
                Plan = new RecurringPaymentPlan
                {
                    CycleType = "monthly",
                    DayOfTheMonth = 1,
                    DayOfTheWeek = 1,
                    Month = 6,
                    Frequency = 10,
                    Amount = 52.95m,
                    StartDate = Convert.ToDateTime("09/01/2017"),
                    EndDate = Convert.ToDateTime("12/01/2018"),
                    MaxRetries = 4,
                    Notes = "This is an updated recurring plan",
                    Active = true,
                    SoftDescriptor = Helper.RequestSoftDescriptor, 
                    DynamicMCC = Helper.RequestDynamicMCC
                },
                IncludeRawObjects = true,
                IncludeRequest = true,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<UpdateRecurringPaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredRecurringPaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredRecurringPaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Unit Tests for Creating a Payment Account, Creating an Installment Plan, Updating the Installment Plan, Retrieving the Installment Plan, and 
        /// deleting the Installment Plan requests. Tests combined in one method to pass the required payment method identifier, the plan identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void Recurring_Billing_Create_Retrieve_Update_And_Delete_Installment_Plan_Requests_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Create the Payment Account
            string paymentMethodId = SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(customerId);
            
            // Create the Installment Plan
            string planId = Recurring_Billing_Create_Installment_Plan_Request_Returns_Successfully(customerId, paymentMethodId);

            // Retrieve the Installment Plan
            Recurring_Billing_Retrieve_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Update the Installment Plan
            Recurring_Billing_Update_Installment_Plan_Request_Returns_Successfully(customerId, planId);
            
            // Delete the Installment Plan
            Recurring_Billing_Delete_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Delete the Payment Account
            SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Customer
            //TODO
        }

        /// <summary>
        /// Successful response returned from an Create Installment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#installment
        /// </summary>
        public string Recurring_Billing_Create_Installment_Plan_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new AddInstallmentPaymentPlanRequest
            {
                CustomerId = customerId,
                Plan = new InstallmentPaymentPlan
                {
                    CycleType = "monthly",
                    DayOfTheMonth = 1,
                    DayOfTheWeek = 1,
                    Frequency = 1,
                    NumberOfPayments = 12,
                    InstallmentAmount = 276.95m,
                    RemainderAmount = 12.90m,
                    BalloonPaymentAddedTo = "FIRST",
                    RemainderAmountAddedTo = "LAST",
                    StartDate = Convert.ToDateTime("10/1/2017"),
                    EndDate = Convert.ToDateTime("10/1/2020"),
                    MaxRetries = 4,
                    PrimaryPaymentMethodId = paymentMethodId,
                    Notes = "This is an installment plan",
                    Active = true,
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                    UserDefinedFields = new List<UserDefinedField>
                    {
                        new UserDefinedField
                        {
                            UdfName = "Udf1",
                            UdfValue = "Udf1_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf2",
                            UdfValue = "Udf2_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf3",
                            UdfValue = "Udf3_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf4",
                            UdfValue = "Udf4_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf5",
                            UdfValue = "Udf5_Value"
                        }
                    }                    
                },

                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<AddInstallmentPaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredInstallmentPaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredInstallmentPaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.PlanId);

            return response.PlanId;
        }

        /// <summary>
        /// Successful response returned from an Update Installment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#updateinstallment
        /// </summary>
        public void Recurring_Billing_Update_Installment_Plan_Request_Returns_Successfully(string customerId, string planId)
        {
            // Arrange
            var request = new UpdateInstallmentPaymentPlanRequest
            {
                CustomerId = customerId,
                PlanId = planId,
                Plan = new InstallmentPaymentPlan
                {
                    CycleType = "monthly",
                    DayOfTheMonth = 1,
                    DayOfTheWeek = 1,
                    Frequency = 1,
                    NumberOfPayments = 15,
                    InstallmentAmount = 300.95m,
                    RemainderAmount = 17.90m,
                    BalloonPaymentAddedTo = "FIRST",
                    RemainderAmountAddedTo = "LAST",
                    StartDate = Convert.ToDateTime("11/01/2017"),
                    EndDate = Convert.ToDateTime("10/01/2020"),
                    MaxRetries = 4,
                    Notes = "This is an updated installment plan",
                    Active = true, 
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<UpdateInstallmentPaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredInstallmentPaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredInstallmentPaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
        }



        /// <summary>
        /// Unit Tests for Creating a Payment Account, Creating an Variable Plan, Updating the Variable Plan, Retrieving the Variable Plan, and 
        /// deleting the Variable Plan requests. Tests combined in one method to pass the required payment method identifier, the plan identifier and to guaranteee the order of operation.
        /// </summary>
        [TestMethod]
        public void Recurring_Billing_Create_Retrieve_Update_And_Delete_Variable_Plan_Requests_Returns_Successfully()
        {
            // Create the Customer
            string customerId = SecureNet_Vault_Create_Customer_Request_Returns_Successfully();

            // Create the Payment Account
            string paymentMethodId = SecureNet_Vault_Create_Payment_Account_Request_Returns_Successfully(customerId);

            // Create the Variable Plan
            string planId = Recurring_Billing_Create_Variable_Payment_Plan_Request_Returns_Successfully(customerId, paymentMethodId);

            // Retrieve the Variable Plan
            Recurring_Billing_Retrieve_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Update the Variable Plan
            Recurring_Billing_Update_Variable_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Delete the Variable Plan
            Recurring_Billing_Delete_Payment_Plan_Request_Returns_Successfully(customerId, planId);

            // Delete the Payment Account
            SecureNet_Vault_Delete_Payment_Account_Request_Returns_Successfully(customerId, paymentMethodId);

            // Delete the Customer
            //TODO
        }
        
        /// <summary>
        /// Successful response returned from an Create Variable Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#variable
        /// </summary>
     
        public string Recurring_Billing_Create_Variable_Payment_Plan_Request_Returns_Successfully(string customerId, string paymentMethodId)
        {
            // Arrange
            var request = new AddVariablePaymentPlanRequest
            {
                CustomerId = customerId,
                Plan = new VariablePaymentPlan
                {
                    PlanStartDate = Convert.ToDateTime("10/01/2017"),
                    PlanEndDate = Convert.ToDateTime("01/01/2020"),
                    PrimaryPaymentMethodId = paymentMethodId,
                    ScheduledPayments = new List<StoredScheduledVariablePaymentPlan>
                    {
                        new StoredScheduledVariablePaymentPlan
                        {
                            Amount = 132.89m,
                            PaymentDate = Convert.ToDateTime("10/01/2017"),
                        }

                    },
                    MaxRetries = 4,
                    Notes = "This is a variable payment plan",
                    UserDefinedFields = new List<UserDefinedField>
                    {
                        new UserDefinedField
                        {
                            UdfName = "Udf1",
                            UdfValue = "Udf1_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf2",
                            UdfValue = "Udf2_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf3",
                            UdfValue = "Udf3_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf4",
                            UdfValue = "Udf4_Value"
                        },
                        new UserDefinedField
                        {
                            UdfName = "Udf5",
                            UdfValue = "Udf5_Value"
                        }
                    },
                    SoftDescriptor = Helper.RequestSoftDescriptor, 
                    DynamicMCC = Helper.RequestDynamicMCC
                },
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<AddVariablePaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredVariablePaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredVariablePaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.PlanId);

            return response.PlanId;
        }

        /// <summary>
        /// Successful response returned from an Update Variable Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#updatevariable
        /// </summary>
        public void Recurring_Billing_Update_Variable_Payment_Plan_Request_Returns_Successfully(string customerId,
            string planId)
        {
            //Arrange
            var request = new UpdateVariablePaymentPlanRequest()
            {
                CustomerId = customerId,
                PlanId = planId,
                Plan = new StoredVariablePaymentPlan()
                {
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                    PlanStartDate = Convert.ToDateTime("07/12/2016"),
                    ScheduledPayments = new List<StoredScheduledVariablePaymentPlan>()
                    {
                        new StoredScheduledVariablePaymentPlan()
                        {
                            ScheduleId = 1093749,
                            PaymentDate = Convert.ToDateTime("12/05/2017"),
                            Amount = 200m
                        }

                    },
                    MaxRetries = 4,
                    Notes = "This is an updated variable Payment Plan"
                },
                DeveloperApplication = new DeveloperApplication()
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<UpdateVariablePaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StoredVariablePaymentPlan.SoftDescriptor, Helper.ResponseSoftDescriptor);
            Assert.AreEqual(response.StoredVariablePaymentPlan.DynamicMCC, Helper.ResponseDynamicMCC);
            Assert.IsTrue(response.Success);
            
        }

        
        /// <summary>
        /// Successful response returned from a Retrieve Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#retrieve
        /// </summary>
        public void Recurring_Billing_Retrieve_Payment_Plan_Request_Returns_Successfully(string customerId, string planId)
        {
            // Arrange
            var request = new RetrievePaymentPlanRequst
            {
                CustomerId = customerId,
                PlanId = planId
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<RetrievePaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Successful response returned from a Delete Payment Plan request.
        /// https://apidocs.securenet.com/docs/recurringbilling.html?lang=csharp#delete
        /// </summary>
        public void Recurring_Billing_Delete_Payment_Plan_Request_Returns_Successfully(string customerId, string planId)
        {
            // Arrange
            var request = new DeletePaymentPlanRequest
            {
                CustomerId = customerId,
                PlanId = planId,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

            var apiContext = new APIContext();
            var controller = new CustomersController();

            // Act
            var response = controller.ProcessRequest<DeletePaymentPlanResponse>(apiContext, request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        #endregion
    }
}
