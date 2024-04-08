using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.AmountConverter.Application.Shared.Dto
{
    /// <summary>
    /// This object is used to map the incoming response of Rapid API using deserialization
    /// </summary>
    public class ApiResponse
    {
        public string? Message { get; set; }
    }
}
