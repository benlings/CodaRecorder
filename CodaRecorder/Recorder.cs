using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    public class Recorder : IMutableRecorder
    {
        private IDictionary<string, int> keyStore = new Dictionary<string, int>();

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
            keyStore.Add(key, value);
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}
