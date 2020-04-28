using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsClient
{
    public class PingRequest
    {
        public PingRequest(string _type, string _value)
        {
            type = _type;
            value = _value;
        }
        public string type { get; set; }
        public string value { get; set; }
    }
    public class PingResponse

    {
        public PingResponse(string _type, string _value)
        {
            type = _type;
            value = _value;
        }
        public string type { get; set; }
        public string value { get; set; }
    }
}
