using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    public class Recorder : IMutableRecorder
    {
        int count = 0;

        public int KeyCount()
        {
            return this.count;
        }

        public int Get(string key)
        {
            return 1;
        }

        public void Upsert(string key, int value)
        {
            this.count++;
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}
