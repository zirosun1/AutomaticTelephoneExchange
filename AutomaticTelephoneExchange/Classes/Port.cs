using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Enums;
using AutomaticTelephoneExchange.Interfaces;

namespace AutomaticTelephoneExchange.Classes
{
    abstract class Port : Interfaces.IPort
    {
        public PortState State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<PortState> ChangedState;
        public event EventHandler<PortState> ChangingState;

        public void ConnectEventsForTerminal(ITerminal terminal)
        {
            throw new NotImplementedException();
        }
    }
}
