using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class RageTaskScheduler : TaskScheduler
    {
        private readonly Thread _mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly ConcurrentQueue<Task> _tasks = new ConcurrentQueue<Task>();

        public RageTaskScheduler()
        {
            _mainThread = Thread.CurrentThread;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks;
        }

        protected override void QueueTask(Task task)
        {
            _tasks.Enqueue(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            if (Thread.CurrentThread != _mainThread)
            {
                return false;
            }

            return TryExecuteTask(task);
        }

        internal void Tick()
        {
            var runs = _tasks.Count;

            while (runs-- > 0 && _tasks.TryDequeue(out Task task))
            {
                TryExecuteTask(task);
            }
        }
    }
}
