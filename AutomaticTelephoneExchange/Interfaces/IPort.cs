using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Enums;

namespace AutomaticTelephoneExchange.Interfaces
{
    interface IPort
    {
        PortState State { get; set; }

        event EventHandler<PortState> ChangedState;

    }
}
