using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    interface IMutableRecorder
    {

        void Upsert(String key, int value);

        void Delete(String key);
    }
}
