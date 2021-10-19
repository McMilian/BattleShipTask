using System;

namespace BattleShipTask.Application.Exceptions
{
    public class BattleshipApplicationException : Exception
    {
        public ApplicationErrorType Type { get; }

        public BattleshipApplicationException(string message, ApplicationErrorType type) : base(message)
        {
            Type = type;
        }
    }
}
