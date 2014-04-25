using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    class Command
    {

    }

    class Upsert : Command
    {
        public String Key { get; protected set; }
        public int Value { get; protected set; }
        public Upsert(string key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
        
    }

    class Delete : Command
    {
        public String Key { get; protected set; }
        public Delete(string key)
        {
            this.Key = key;
        }

    }

    class Clear : Command
    {
        public Clear()
        {
            // no data, nothing to do
        }
    }

    class Invalid : Command
    {
        public String Message { get; private set; }
        public Invalid(string errorMessage)
        {
            this.Message = errorMessage;
        }
    }
}
