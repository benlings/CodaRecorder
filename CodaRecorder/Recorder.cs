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

        private List<IRecorderObserver> observers = new List<IRecorderObserver>();

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
            var command = parser.Parse(commandMessage);
            if (command is Invalid)
            {
            }
            else
            {   
                command.ActOn(this);
                foreach (var observer in this.observers)
                {
                    observer.KeysChanged(new HashSet<string>(new string[] {"key"}), new HashSet<string>(new string[] {}), new Dictionary<string, int>());
                }
            }
        }

        public void RegisterObserver(IRecorderObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Clear()
        {
            keyStore.Clear();
        }
    }
}
