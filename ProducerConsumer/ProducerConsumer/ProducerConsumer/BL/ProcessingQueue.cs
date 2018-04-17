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
        private readonly EventWaitHandle _waitHandler;
        private readonly Queue<string> _queue;
        private static readonly object LockObject = new object();

        public ProcessingQueue()
        {
            _queue = new Queue<string>();
            _waitHandler = new AutoResetEvent(false);
        }

        public void Produce(string message)
        {
            lock (LockObject)
            {
                _queue.Enqueue(message);
            }
            _waitHandler.Set();
        }

        public void Consume()
        {
            while (true)
            {
                string message = null;
                lock (LockObject)
                {
                    if (_queue.Any())
                        message = _queue.Dequeue();
                }

                if (message != null)
                {
                    Console.WriteLine($"\nPrzetwarzanie wiadomości: {message}");
                    Thread.Sleep(3000);
                }
                else
                    _waitHandler.WaitOne();
            }
        }
    }
}
