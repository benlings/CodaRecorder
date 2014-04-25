using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodaRecorder
{
    class ChangesCalc
    {
        private readonly Dictionary<string, int> oldDictionary;
        private readonly Dictionary<string, int> newDictionary;

        public ChangesCalc(Dictionary<string, int> old, Dictionary<string, int> newDict)
        {
            this.oldDictionary = old;
            this.newDictionary = newDict;
        }

        internal void CalculateChanges()
        {
            InsertedKeys = new HashSet<string>();
            DeletedKeys = new HashSet<string>();

            foreach (string key in this.newDictionary.Keys)
            {
                if (!this.oldDictionary.Keys.Contains(key))
                {
                    InsertedKeys.Add(key);
                }
            }

            foreach (string key in this.oldDictionary.Keys)
            {
                if (!this.newDictionary.Keys.Contains(key))
                {
                    DeletedKeys.Add(key);
                }
            }
        }

        public ISet<string> InsertedKeys { get; private set; }
        public ISet<string> DeletedKeys { get; private set; }
    }
}
