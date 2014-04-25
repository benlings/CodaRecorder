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

            switch (parts[0])
            {
                case "value":
                    if (parts.Length != 3)
                    {
                        return new Invalid("Incorrectly formatted value string");
                    }

                    int val;
                    if (int.TryParse(parts[2], out val))
                    {
                        return new Upsert(parts[1], val);
                    }
                    else
                    {
                        return new Invalid("Non-integer value");
                    }
                    
                default:
                    return new Invalid("Unknown command");
            }
        }
    }
}
