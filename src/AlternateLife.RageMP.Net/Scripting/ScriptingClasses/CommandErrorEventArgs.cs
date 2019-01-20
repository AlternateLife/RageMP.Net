using System;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    public class CommandErrorEventArgs : EventArgs
    {
        public CommandError CommandError { get; }
        public string ErrorMessage { get; }

        public IPlayer Player { get; set; }

        public CommandErrorEventArgs(IPlayer player, CommandError commandError, string errorMessage)
        {
            CommandError = commandError;
            ErrorMessage = errorMessage;
            Player = player;
        }
    }
}