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
            var parts = message.Split(' ');
            return new Upsert(parts[1], int.Parse(parts[2]));
        }
    }
}
