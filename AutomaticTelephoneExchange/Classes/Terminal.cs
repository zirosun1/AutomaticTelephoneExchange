using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Structs;

namespace AutomaticTelephoneExchange.Classes
{
    abstract class Terminal : Interfaces.ITerminal
    {
        public PhoneNumber Number => throw new NotImplementedException();

        public event EventHandler Online;
        public event EventHandler Offline;
        public event EventHandler IncomingCall;
        public event EventHandler OutcomingCall;
        public event EventHandler Connection;
        public event EventHandler Disconnection;

        public void Answer()
        {
            throw new NotImplementedException();
        }

        public void Call(PhoneNumber number)
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void ConnectEventsForPort(IPort port)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }
    }
}
