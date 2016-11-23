using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNetRestApiSDK_UnitTest
{

    public static class Helper
    {
        private static bool? _isSoftDescriptorEnabled;
        private const string SoftDescriptorValue = "Valid Soft Descriptor";

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
    }
}