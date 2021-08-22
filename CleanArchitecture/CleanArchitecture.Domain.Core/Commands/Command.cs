using CleanArchitecture.Domain.Core.Events;
using System;

namespace CleanArchitecture.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
