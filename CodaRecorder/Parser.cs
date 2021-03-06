﻿using System;
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
                    return ParseValueCommand(parts);
                case "drop":
                    return ParseDropCommand(parts);
                case "clear":
                    return ParseClearCommand(parts);

                default:
                    return new Invalid("Unknown command");
            }
        }

        private static Command ParseValueCommand(string[] parts)
        {
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
        }

        private static Command ParseDropCommand(string[] parts)
        {
            if (parts.Length != 2)
            {
                return new Invalid("Incorrectly formatted drop string");
            }

            return new Delete(parts[1]);
        }

        private static Command ParseClearCommand(string[] parts)
        {
            if (parts.Length != 1)
            {
                return new Invalid("Incorrectly formatted clear string");
            }

            return new Clear();
        }
    }
}
