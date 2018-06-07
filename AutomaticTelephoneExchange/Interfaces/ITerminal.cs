using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Structs;

namespace AutomaticTelephoneExchange.Interfaces
{
    interface ITerminal
    {
        PhoneNumber Number { get; }

        event EventHandler Online;
        event EventHandler Offline;
        event EventHandler IncomingCall;
        event EventHandler OutcomingCall;
        event EventHandler Connection;
        event EventHandler Disconnection;

        void Call(PhoneNumber number);
        void Drop();
        void Answer();
        void Connect();
        void Disconnect();
        void ConnectEventsForPort(IPort port);
    }
}
