using System;
using System.Collections.Generic;
using System.Text;
using MKopaSolar.Contracts.common;

namespace MKopaSolar.Contracts.Requests
{
    public class SendSmsRequest
    {
        public SharedProperties Body { get; set; }
    }
}
