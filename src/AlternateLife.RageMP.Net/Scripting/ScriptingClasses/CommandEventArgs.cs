using System;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    public class CommandEventArgs : EventArgs
    {
        public bool Cancelled { get; set; }
    }
}
