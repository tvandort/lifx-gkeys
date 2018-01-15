using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifx_gkeys
{
    class Payload
    {
        [JsonProperty(PropertyName = "state")]
        [JsonConverter(typeof(StringEnumConverter))]
        LightsState State { get; }

        public Payload(LightsState state)
        {
            State = state;
        }
    }
}
