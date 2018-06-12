using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Enums;

namespace AutomaticTelephoneExchange.Events
{
    public class EventOfAnswerArgs :EventArgs, ICallEventArgs
    {
        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public CallState StateOfCall { get; private set; }
        public Guid Id { get; private set; }
        public EventOfAnswerArgs(int number, int target, CallState state)
        {
            Number = number;
            TargetNumber = target;
            StateOfCall = state;
        }
        public EventOfAnswerArgs(int number, int target, CallState state, Guid id)
        {
            Number = number;
            TargetNumber = target;
            StateOfCall = state;
            Id = id;
        }
    }
}
