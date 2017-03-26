using System;
using System.Configuration;

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
    }
}