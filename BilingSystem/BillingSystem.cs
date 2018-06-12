using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
    public class BillingSystem : IBillingSystem
    {
        private IData<CallInfo> _data;
        public BillingSystem(IData<CallInfo> data)
        {
            _data = data;
        }
        public CallHistory GetCallHistory(int telephoneNumber)
        {
            var calls = _data.GetInformationList().
                Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber).ToList();
            var callHistory = new CallHistory();
            foreach (var call in calls)
            {
                TypeOfCall callType;
                int number;
                if (call.Number == telephoneNumber)
                {
                    callType = TypeOfCall.OutgoingCall;
                    number = call.TargetNumber;
                }
                else
                {
                    callType = TypeOfCall.IncomingCall;
                    number = call.Number;
                }
                var callRecord = new CallRecord(callType, number, call.StartOfCall, new DateTime((call.EndOfCall - call.StartOfCall).Ticks), call.CostOfCall);
                callHistory.AddCallRecord(callRecord);
            }
            return callHistory;
        }
    }
}
