using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProducerConsumer.BL;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var processingQueue = new ProcessingQueue();

            Task.Factory.StartNew(processingQueue.Consume);

            while (true)
            {
                var input = Console.ReadLine();
                processingQueue.Produce(input);
            }          
        }
    }
}
