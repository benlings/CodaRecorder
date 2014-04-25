using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    public interface IRecorderObserver
    {
        void KeysChanged(ISet<string> added, ISet<string> removed, IDictionary<string, int> updated);
        void InvalidCommand(String message);

    }
}
