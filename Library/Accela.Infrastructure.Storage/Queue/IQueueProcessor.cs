using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    public interface IQueueProcessor<T> where T : class
    {
        void Start();

        void Cancel();

        void Enqueue(T[] queueItems);

        void Enqueue(T queueItem);
    }
}
