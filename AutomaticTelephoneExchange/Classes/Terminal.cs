using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Structs;
using AutomaticTelephoneExchange.Events;
using AutomaticTelephoneExchange.Enums;

namespace AutomaticTelephoneExchange.Classes
{
    public class Terminal
    {
        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
        }

        private Port TerminalPort { get; set; }
        private Guid Id { get; set; }
        public event EventHandler<EventOfCallArgs> EventOfCall;
        public event EventHandler<EventOfAnswerArgs> EventOfAnswer;
        public event EventHandler<EventOfEndCallArgs> EventOfEndCall;
        public Terminal(int number, Port port)
        {
            _number = number;
            TerminalPort = port;
        }
        public void ConnectToATS()
        {
            if (TerminalPort.Connect(this))
            {
                TerminalPort.PortCallEvent += TakeIncomingCall;
                TerminalPort.PortAnswerEvent += TakeAnswer;
            }
        }
        public void DisConnectToATS()
        {
            if (TerminalPort.Connect(this))
            {
                TerminalPort.PortCallEvent -= TakeIncomingCall;
                TerminalPort.PortAnswerEvent -= TakeAnswer;
            }
        }

        protected virtual void SafeEventOfCall(int targetNumber)
        {
            if (EventOfCall != null)
                EventOfCall(this, new EventOfCallArgs(_number, targetNumber));
        }
        public void Call(int targetNumber)
        {
            SafeEventOfCall(targetNumber);
        }


        protected virtual void SafeEventOfAnswer(int targetNumber, CallState stateOfCall, Guid id)
        {
            if (EventOfAnswer != null)
            {
                EventOfAnswer(this, new EventOfAnswerArgs(Number, targetNumber, stateOfCall, id));
            }
        }
        public void Answer(int targetNumber, CallState stateOfCall, Guid id)
        {
            SafeEventOfAnswer(targetNumber, stateOfCall, id);
        }


        protected virtual void SafeEventOfEndCall(Guid id)
        {
            if (EventOfEndCall != null)
                EventOfEndCall(this, new EventOfEndCallArgs(id, _number));
        }
        public void EndCall()
        {
            SafeEventOfEndCall(Id);
        }


        public void TakeIncomingCall(object sender, EventOfCallArgs e)
        {

            bool flag = true;
            Id = e.Id;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.Number, e.TargetNumber);
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.Number, CallState.Answer, e.Id);
                }
                else if (k == 'N' || k == 'n')
                {
                    flag = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
            }
        }
        public void AnswerToCall(int target, CallState state, Guid id)
        {
            SafeEventOfAnswer(target, state, id);
        }
        public void TakeAnswer(object sender, EventOfAnswerArgs e)
        {
            Id = e.Id;
            Console.WriteLine("He answered!!!");
            if (e.StateOfCall == CallState.Answer)
            {
                Console.WriteLine("Terminal {0} have answered on call from terminal {1}", e.TargetNumber, e.Number);
            }
            else
            {
                Console.WriteLine("Terminal {0} have rejected call from terminal {1}", e.TargetNumber, e.Number);
            }
        }
    }
}
