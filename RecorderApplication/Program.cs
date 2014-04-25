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
        static void Main(string[] args)
        {
            Console.WriteLine("Recorder Application");

            var recorder = new Recorder();
            while (true)
            {
                String command = Console.ReadLine();
                recorder.Do(command);
                Console.WriteLine("{0} Entries", recorder.KeyCount);
            }
        }
    }
}
