using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    class Parser
    {
        internal Command Parse(string message)
        {
            return new Upsert("key", 2);
        }
    }
}
