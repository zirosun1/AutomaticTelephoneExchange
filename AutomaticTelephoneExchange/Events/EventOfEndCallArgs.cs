using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;

namespace AutomaticTelephoneExchange.Events
{
    public class EventOfEndCallArgs :EventArgs, ICallEventArgs
    {
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public int TargetNumber { get; private set; }

        public EventOfEndCallArgs(Guid id, int number)
        {
            Id = id;
            Number = number;
        }
    }
}
