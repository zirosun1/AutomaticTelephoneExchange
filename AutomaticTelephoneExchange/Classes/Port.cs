using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Enums;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Events;

namespace AutomaticTelephoneExchange.Classes
{
   public class Port
    {
        public PortState State { get; set; }
        private bool stateOfPort;

        public event EventHandler<EventOfCallArgs> PortCallEvent;
        public event EventHandler<EventOfAnswerArgs> PortAnswerEvent;
        public event EventHandler<EventOfCallArgs> CallEvent;
        public event EventHandler<EventOfAnswerArgs> AnswerEvent;
        public event EventHandler<EventOfEndCallArgs> EndCallEvent;

        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.EventOfCall += CallingTo;
                terminal.EventOfAnswer += AnswerTo;
                stateOfPort = true;
            }
            return stateOfPort;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.EventOfCall -= CallingTo;
                terminal.EventOfAnswer -= AnswerTo;
                terminal.EventOfEndCall -= EndCall;
                stateOfPort = false;
            }
            return false;
        }


        private void SafeIncomingCallEvent(int number, int target)
        {
            if (PortCallEvent != null)
                PortCallEvent(this, new EventOfCallArgs(number, target));
        }
        private void SafeIncomingCallEvent(int number, int target, Guid id)
        {
            if (PortCallEvent != null)
                PortCallEvent(this, new EventOfCallArgs(number, target));
        }
        public void IncomingCall(int number, int target)
        {
            SafeIncomingCallEvent(number, target);
        }
        public void IncomingCall(int number, int target, Guid id)
        {
            SafeIncomingCallEvent(number, target, id);
        }


        private void SafeAnswerCallEvent(int number, int target, CallState state)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventOfAnswerArgs(number, target, state));
        }
        private void SafeAnswerCallEvent(int number, int target, CallState state, Guid id)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventOfAnswerArgs(number, target, state, id));
        }
        public void AnswerCall(int number, int target, CallState state)
        {
            SafeAnswerCallEvent(number, target, state);
        }
        public void AnswerCall(int number, int target, CallState state, Guid id)
        {
            SafeAnswerCallEvent(number, target, state, id);
        }


        protected virtual void SafeCallingToEvent(int number, int targetNumber)
        {
            if (CallEvent != null)
            {
                CallEvent(this, new EventOfCallArgs(number, targetNumber));
            }
        }
        private void CallingTo(object sender, EventOfCallArgs e)
        {
            SafeCallingToEvent(e.Number, e.TargetNumber);
        }


        protected virtual void SafeAnswerToEvent(EventOfAnswerArgs eventArgs)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new EventOfAnswerArgs(eventArgs.Number, eventArgs.TargetNumber, eventArgs.StateOfCall, eventArgs.Id));
            }
        }
        private void AnswerTo(object sender, EventOfAnswerArgs e)
        {
            SafeAnswerToEvent(e);
        }


        protected virtual void SafeEndCallEvent(Guid id, int number)
        {
            if (EndCallEvent != null)
            {
                EndCallEvent(this, new EventOfEndCallArgs(id, number));
            }
        }
        private void EndCall(object sender, EventOfEndCallArgs e)
        {
            SafeEndCallEvent(e.Id, e.Number);
        }
    }
}
