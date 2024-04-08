using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.AmountConverter.Application.Shared.Configuration
{
    /// <summary>
    /// Configuration for Rapid API. This includes the endpoint, keys and host needed for the request
    /// </summary>
    public class AmountConverterConfiguration
    {
        public string RapidApiUrl { get; set; }
        public string ConverterEndpoint { get; set; }
        public string Key { get; set; }
        public string Host { get; set; }
    }
}
