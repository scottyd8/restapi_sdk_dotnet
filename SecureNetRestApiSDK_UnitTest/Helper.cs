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

        public static string SoftDescriptor
        {
            get
            {
                if (!_isSoftDescriptorEnabled.HasValue)
                {
                    _isSoftDescriptorEnabled = bool.Parse(ConfigurationManager.AppSettings["isSoftDescriptorEnabled"]);
                }

                return Convert.ToBoolean(_isSoftDescriptorEnabled) ? "Valid Soft Descriptor" : string.Empty;
            }
        }

    }
}