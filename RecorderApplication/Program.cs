using CodaRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecorderApplication
{
    class Program
    {
        public class Notifier : IRecorderObserver
        {
            public void KeysChanged(ISet<string> added, ISet<string> removed, IDictionary<string, int> updated)
            {
                Console.WriteLine("Added: {0}, Removed: {1}", DumpCollection(added), DumpCollection(removed));
            }

            public String DumpCollection(IEnumerable<object> collection)
            {
                return String.Join(",", collection);
            }

            public void InvalidCommand(string message)
            {
                Console.WriteLine("Invalid command: {0}", message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Recorder Application");

            var recorder = new Recorder();
            recorder.RegisterObserver(new Notifier());
            while (true)
            {
                String command = Console.ReadLine();
                recorder.Do(command);
                Console.WriteLine("{0} Entries", recorder.KeyCount);
            }
        }
    }
}
