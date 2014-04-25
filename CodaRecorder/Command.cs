using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    class Command
    {

        public String Key { get; protected set; }
        public int Value { get; protected set; }
    }

    class Upsert : Command
    {
        public Upsert(string key, int value)
        {
            this.Key = key;
            this.Value = value;
        }


        internal void ActOn(IMutableRecorder recorder)
        {
            recorder.Upsert(Key, Value);
        }
    }

    class Invalid : Command
    {

        public Invalid(string errorMessage)
        {
            this.Message = errorMessage;
        }
        public String Message { get; private set; }
    }
}
