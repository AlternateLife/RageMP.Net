using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class Utility : IUtility
    {
        private readonly Plugin _plugin;

        internal Utility(Plugin plugin)
        {
            _plugin = plugin;
        }

        public uint Joaat(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return 0;
            }

            var characters = Encoding.UTF8.GetBytes(data.ToLower());

            uint hash = 0;

            foreach (var t in characters)
            {
                hash += t;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }

        public IList<uint> Joaat(IList<string> input)
        {
            Contract.NotNull(input, nameof(input));

            var result = new uint[input.Count];

            for (var i = 0; i < input.Count; i++)
            {
                result[i] = Joaat(input[i]);
            }

            return result;
        }

        public Task Schedule(Action action, bool forceSchedule = false)
        {
            return _plugin.Schedule(action, forceSchedule);
        }

        public Task<T> Schedule<T>(Func<T> action, bool forceSchedule = false)
        {
            return _plugin.Schedule(action, forceSchedule);
        }
    }
}
