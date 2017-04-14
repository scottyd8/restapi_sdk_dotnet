using SNET.Core;
﻿using SecureNetRestApiSDK.Api.Models;

namespace SecureNetRestApiSDK.Api.Requests
{
    public class BatchCloseRequest : SecureNetRequest
    {
        #region Properties

        public DeveloperApplication DeveloperApplication { get; set; }

        #endregion
        #region Methods

        public override string GetUri()
        {
            return "api/batches/Close";
        }

        public override HttpMethodEnum GetMethod()
        {
            return HttpMethodEnum.POST;
        }

        #endregion
    }
}
