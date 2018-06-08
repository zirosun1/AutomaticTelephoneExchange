using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTelephoneExchange.Interfaces
{
    interface IATE
    {
        void ConnectEventsForTerminal(ITerminal terminal);
        void ConnectEventsForPort(IPort port);

        
    }
}
