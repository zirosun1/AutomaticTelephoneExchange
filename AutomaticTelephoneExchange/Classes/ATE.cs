﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Interfaces;
using AutomaticTelephoneExchange.Structs;
using AutomaticTelephoneExchange.Events;
using BilingSystem;
using BilingSystem.Enums;

namespace AutomaticTelephoneExchange.Classes
{
    public class ATE : IATE
    {
        private IList<CallInfo> _calls = new List<CallInfo>();
        private IDictionary<int, Tuple<Port, IContract>> Subscribers { get; set; }

        public ATE()
        {
            Subscribers = new Dictionary<int, Tuple<Port, IContract>>();
        }

        public Terminal NewTerminal(IContract contract)
        {
            var newPort = new Port();
            newPort.AnswerEvent += Calling;
            newPort.CallEvent += Calling;
            newPort.EndCallEvent += Calling;
            Subscribers.Add(contract.Number, new Tuple<Port, IContract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public IContract SignContract(Client subscriber, TypeOfTariff typeOfTariff)
        {
            Contract contract = new Contract(subscriber, typeOfTariff);
            return contract;
        }

        public void Calling(object sender, ICallEventArgs e)
        {
            if ((Subscribers.ContainsKey(e.TargetNumber) && e.TargetNumber != e.Number) || e is EventOfEndCallArgs)
            {
                CallInfo callInfo = null;
                Port targetPort;
                Port port;
                int number = 0;
                int targetNumber = 0;
                if (e is EventOfEndCallArgs)
                {
                    var callListFirst = _calls.First(x => x.Id.Equals(e.Id));
                    if (callListFirst.Number == e.Number)
                    {
                        targetPort = Subscribers[callListFirst.TargetNumber].Item1;
                        port = Subscribers[callListFirst.Number].Item1;
                        number = callListFirst.Number;
                        targetNumber = callListFirst.TargetNumber;
                    }
                    else
                    {
                        port = Subscribers[callListFirst.TargetNumber].Item1;
                        targetPort = Subscribers[callListFirst.Number].Item1;
                        targetNumber = callListFirst.Number;
                        number = callListFirst.TargetNumber;
                    }
                }
                else
                {
                    targetPort = Subscribers[e.TargetNumber].Item1;
                    port = Subscribers[e.Number].Item1;
                    targetNumber = e.TargetNumber;
                    number = e.Number;
                }
                if (targetPort.State == Enums.PortState.Connect && port.State == Enums.PortState.Connect)
                {
                    var tuple = Subscribers[number];
                    var targetTuple = Subscribers[targetNumber];

                    if (e is EventOfAnswerArgs)
                    {

                        var answerArgs = (EventOfAnswerArgs)e;

                        if (!answerArgs.Id.Equals(Guid.Empty) && _calls.Any(x => x.Id.Equals(answerArgs.Id)))
                        {
                            callInfo = _calls.First(x => x.Id.Equals(answerArgs.Id));
                        }

                        if (callInfo != null)
                        {
                            targetPort.AnswerCall(answerArgs.Number, answerArgs.TargetNumber, answerArgs.StateOfCall, callInfo.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(answerArgs.Number, answerArgs.TargetNumber, answerArgs.StateOfCall);
                        }
                    }
                    if (e is EventOfCallArgs)
                    {
                        if (tuple.Item2.Client.Account > tuple.Item2.Tariff.PricePerMinute)
                        {
                            var callArgs = (EventOfCallArgs)e;

                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                callInfo = new CallInfo(
                                    callArgs.Number,
                                    callArgs.TargetNumber,
                                    DateTime.Now);
                                _calls.Add(callInfo);
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && _calls.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                callInfo = _calls.First(x => x.Id.Equals(callArgs.Id));
                            }
                            if (callInfo != null)
                            {
                                targetPort.IncomingCall(callArgs.Number, callArgs.TargetNumber, callInfo.Id);
                            }
                            else
                            {
                                targetPort.IncomingCall(callArgs.Number, callArgs.TargetNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not enough money on the terminal {0}!", e.Number);

                        }
                    }
                    if (e is EventOfEndCallArgs)
                    {
                        var args = (EventOfEndCallArgs)e;
                        callInfo = _calls.First(x => x.Id.Equals(args.Id));
                        callInfo.EndOfCall = DateTime.Now;
                        var sumOfCall = tuple.Item2.Tariff.PricePerMinute * TimeSpan.FromTicks((callInfo.EndOfCall - callInfo.StartOfCall).Ticks).TotalMinutes;
                        callInfo.CostOfCall = (int)sumOfCall;
                        targetTuple.Item2.Client.WithdrawMoney(callInfo.CostOfCall);
                        targetPort.AnswerCall(args.Number, args.TargetNumber, Enums.CallState.Reject, callInfo.Id);
                    }
                }

            }
            else if (!Subscribers.ContainsKey(e.TargetNumber))
            {
                Console.WriteLine("Trying to call a non-existent number".ToUpper());
            }
            else
            {
                Console.WriteLine("Trying to call your own number".ToUpper());
            }
        }
        public IList<CallInfo> GetInformationList()
        {
            return _calls;
        }
    }
    }
}
