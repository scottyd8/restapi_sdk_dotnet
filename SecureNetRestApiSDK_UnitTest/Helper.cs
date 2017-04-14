using System;
using System.Configuration;
using SecureNetRestApiSDK.Api.Models;
using SecureNetRestApiSDK.Api.Requests;
using SecureNetRestApiSDK.Api.Responses;

namespace SecureNetRestApiSDK_UnitTest
{

    public static class Helper
    {
        private static bool? _isSoftDescriptorEnabled;
        private const string SoftDescriptorValue = "Valid Soft Descriptor";

        private static bool? _isDynamicMCCEnabled;
        private const string DynamicMCC = "1234";

        public static string RequestSoftDescriptor
        {
            get
            {
                InitSoftDescriptorConfiguration();
                return Convert.ToBoolean(_isSoftDescriptorEnabled) ? SoftDescriptorValue : null;
            }
        }

        public static string ResponseSoftDescriptor
        {
            get
            {
                InitSoftDescriptorConfiguration();
                return Convert.ToBoolean(_isSoftDescriptorEnabled) ? SoftDescriptorValue : string.Empty;
            }
        }

        private static void InitSoftDescriptorConfiguration()
        {
            if (!_isSoftDescriptorEnabled.HasValue)
            {
                _isSoftDescriptorEnabled = bool.Parse(ConfigurationManager.AppSettings["isSoftDescriptorEnabled"]);
            }
        }

        public static string RequestDynamicMCC
        {
            get
            {
                InitDynamicMCCConfiguration();
                return Convert.ToBoolean(_isDynamicMCCEnabled) ? DynamicMCC : null;
            }
        }

        public static string ResponseDynamicMCC
        {
            get
            {
                InitDynamicMCCConfiguration();
                return Convert.ToBoolean(_isDynamicMCCEnabled) ? DynamicMCC : string.Empty;
            }
        }

        private static void InitDynamicMCCConfiguration()
        {
            if (!_isDynamicMCCEnabled.HasValue)
            {
                _isDynamicMCCEnabled = bool.Parse(ConfigurationManager.AppSettings["isDynamicMCCEnabled"]);
            }
        }

        public static string GetCATIndicatorValue()
        {
            return ((int) PosCardholderActivatedTerminal.TransponderTransaction).ToString();
        }

        #region requests 

        public static AuthorizeRequest GetAnAuthorizeRequest()
        {
            return new AuthorizeRequest
            {
                Amount = 11.00m,
                Card = GetACardInfo(),
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
                ExtendedInformation = new ExtendedInformation
                {
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                }
            };
        }

        public static PriorAuthCaptureRequest GetAPriorAuthCaptureRequest(int transactionId)
        {
            return new PriorAuthCaptureRequest
            {
                Amount = 11.00m,
                TransactionId = transactionId,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
            };
        }

        public static ChargeRequest GetAChargeRequest()
        {
            return new ChargeRequest
            {
                Amount = 11.00m,
                Card = GetACardInfo(),
            DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
                ExtendedInformation = new ExtendedInformation
                {
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                },
            };
        }

        public static VerifyRequest GetAVerifyRequest()
        {
            return new VerifyRequest()
            {
                Amount = 11.00m,
                Card = GetACardInfo(),
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
                ExtendedInformation = new ExtendedInformation
                {
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                },
            };
        }

        public static Address GetAnAddress()
        {
            return new Address
            {
                Line1 = "123 Main St.",
                City = "Austin",
                State = "TX",
                Zip = "78759"
            };
        }

        public static Card GetACardInfo()
        {
            return new Card
            {
                Number = "4444 3333 2222 1111",
                ExpirationDate = "06/2017",
                Address = GetAnAddress()
            };
        }

        public static CreditRequest GetACreditRequest()
        {
           return new CreditRequest
            {
                Amount = 10,
                Card = GetACardInfo(),
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                },
                ExtendedInformation = new ExtendedInformation
                {
                    SoftDescriptor = Helper.RequestSoftDescriptor,
                    DynamicMCC = Helper.RequestDynamicMCC,
                }
            };
        }

        public static RefundRequest GetARefundRequest(int transactionId)
        {
            return new RefundRequest
            {
                TransactionId = transactionId,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };
        }

        public static VoidRequest GetAVoidRequest(int transactionId)
        {
            return new VoidRequest
            {
                TransactionId = transactionId,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };

        }

        public static BatchCloseRequest GetABatchCloseRequest()
        {
            return new BatchCloseRequest
            {
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };
        }

        public static TransactionSearchRequest GetAnTransactionSearchRequest()
        {
            return new TransactionSearchRequest
            {
                StartDate = Convert.ToDateTime("02/01/2016"),
                EndDate = Convert.ToDateTime("05/31/2017"),
                Amount = 11.0m,
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };
        }

        public static TransactionUpdateRequest GetAnTransactionUpdateRequest()
        {
            return new TransactionUpdateRequest
            {
                DutyAmount = "1.07",
                DeveloperApplication = new DeveloperApplication
                {
                    DeveloperId = 12345678,
                    Version = "1.2"
                }
            };
        }
        #endregion
    }
}