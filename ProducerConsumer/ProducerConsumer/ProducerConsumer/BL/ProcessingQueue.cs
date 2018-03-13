using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer.BL
{
    public class ProcessingQueue
    {
        private readonly Queue<string> _queue;
        private static readonly Object _lockObject = new object();

        public ProcessingQueue()
        {
            _queue = new Queue<string>();
        }

        public void Produce(string message)
        {
            lock (_lockObject)
            {
                _queue.Enqueue(message);
            }          
        }

        public void Consume()
        {
            lock (_lockObject)
            {
                while (true)
                {
                    if (!_queue.Any())
                        continue;

                    var messageFromQueue = _queue.Dequeue();
                    Thread.Sleep(10000);//10 seconds              
                    Console.WriteLine($"Message {messageFromQueue} has been processed.");
                }
            }
        }
    }
}
