using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
    public class CallRecord
    {
        public TypeOfCall TypeOfCall { get; private set; }
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }
        public int Amount { get; private set; }
        public CallRecord(TypeOfCall typeOfCall, int number, DateTime date, DateTime time, int amount)
        {
            TypeOfCall = typeOfCall;
            Number = number;
            Date = date;
            Time = time;
            Amount = amount;
        }
    }
}
