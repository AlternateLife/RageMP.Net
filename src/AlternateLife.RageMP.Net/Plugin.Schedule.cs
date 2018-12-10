using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlternateLife.RageMP.Net
{
    internal partial class Plugin
    {
        internal Task Schedule(Action action, bool forceSchedule = false)
        {
            if (forceSchedule == false && IsInMainThread())
            {
                try
                {
                    action();

                    return Task.CompletedTask;
                }
                catch (Exception e)
                {
                    return Task.FromException(e);
                }
            }

            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, _taskScheduler);
        }

        internal Task<T> Schedule<T>(Func<T> action, bool forceSchedule = false)
        {
            if (forceSchedule == false && IsInMainThread())
            {
                try
                {
                    return Task.FromResult(action());
                }
                catch (Exception e)
                {
                    return Task.FromException<T>(e);
                }
            }

            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, _taskScheduler);
        }

        internal void TickScheduler()
        {
            _taskScheduler.Tick();
        }

        public bool IsInMainThread()
        {
            return Thread.CurrentThread.ManagedThreadId == _mainThreadId;
        }
    }
}
