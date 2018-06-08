using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Structs;

namespace AutomaticTelephoneExchange.Classes
{
    abstract class ATE : Interfaces.IATE
    {
        public ATE(ICollection<ITerminal> terminals, ICollection<IPort> ports)
        {
            _terminals = terminals;
            _ports = ports;
            _portMapping = new Dictionary<PhoneNumber, IPort>();
        }
        private ICollection<ITerminal> _terminals;
        private ICollection<IPort> _ports;
        private IDictionary<PhoneNumber, IPort> _portMapping;
        public void ConnectEventsForPort(IPort port)
        {
            throw new NotImplementedException();
        }

        public void ConnectEventsForTerminal(ITerminal terminal)
        {
            throw new NotImplementedException();
        }
    }
}
