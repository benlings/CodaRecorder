using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    abstract class Command
    {
        internal abstract void ActOn(IMutableRecorder recorder);
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


        internal override void ActOn(IMutableRecorder recorder)
        {
            recorder.Upsert(Key, Value);
        }
    }

    class Delete : Command
    {
        public String Key { get; protected set; }
        public Delete(string key)
        {
            this.Key = key;
        }


        internal override void ActOn(IMutableRecorder recorder)
        {
            recorder.Delete(Key);
        }
    }

    class Clear : Command
    {
        public Clear()
        {
            // no data, nothing to do
        }

        internal override void ActOn(IMutableRecorder recorder)
        {
            recorder.Clear();
        }
    }

    class Invalid : Command
    {
        public String Message { get; private set; }
        public Invalid(string errorMessage)
        {
            this.Message = errorMessage;
        }

        internal override void ActOn(IMutableRecorder recorder)
        {
            throw new NotImplementedException();
        }
    }
}
