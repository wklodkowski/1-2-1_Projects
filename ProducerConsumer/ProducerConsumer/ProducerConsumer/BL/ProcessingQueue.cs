using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer.BL
{
    public class ProcessingQueue
    {
        private readonly Queue<string> _queue;

        public ProcessingQueue()
        {
            _queue = new Queue<string>();
        }

        public void Push(string message)
        {
            _queue.Enqueue(message);
        }

        public void Pop()
        {
            
        }
    }
}
