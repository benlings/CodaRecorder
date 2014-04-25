using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    abstract class Command
    {

        public String Key { get; protected set; }
        public int Value { get; protected set; }

        internal abstract void ActOn(IMutableRecorder recorder);
    }

    class Upsert : Command
    {
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
        public Delete(string key)
        {
            this.Key = key;
        }


        internal override void ActOn(IMutableRecorder recorder)
        {
            throw new NotImplementedException();
        }
    }

    class Invalid : Command
    {

        public Invalid(string errorMessage)
        {
            this.Message = errorMessage;
        }
        public String Message { get; private set; }

        internal override void ActOn(IMutableRecorder recorder)
        {
            throw new NotImplementedException();
        }
    }
}
