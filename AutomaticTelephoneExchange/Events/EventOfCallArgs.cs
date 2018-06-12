using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;

namespace AutomaticTelephoneExchange.Events
{
    public class EventOfCallArgs : ICallEventArgs
    {
        public int Number => throw new NotImplementedException();

        public int TargetNumber => throw new NotImplementedException();

        public Guid Id => throw new NotImplementedException();
    }
}
