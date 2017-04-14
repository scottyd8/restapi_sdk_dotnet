using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNetRestApiSDK_UnitTest
{
    public enum PosCardholderActivatedTerminal
    {
        NotCatTransaction = 0,
        AtmWithPin = 1,
        SelfServiceTerminal = 2,
        LimitedAmountTerminal = 3,
        InFlightCommerce = 4,
        ElectronicCommerce = 6,
        TransponderTransaction = 7,
    }
}
