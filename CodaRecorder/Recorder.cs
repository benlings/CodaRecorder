using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    public class Recorder : IMutableRecorder
    {
        private readonly IDictionary<string, int> keyStore = new Dictionary<string, int>();
        private readonly Parser parser = new Parser();

        public int KeyCount
        {
            get
            {
                return keyStore.Count;
            }
        }

        public int Get(string key)
        {
            return keyStore[key];
        }

        public void Upsert(string key, int value)
        {
            keyStore[key] = value;
        }

        public void Delete(string key)
        {
            keyStore.Remove(key);
        }

        public void Do(string commandMessage)
        {
            parser.Parse(commandMessage).ActOn(this);
        }

        internal void Clear()
        {
            keyStore.Clear();
        }
    }
}
