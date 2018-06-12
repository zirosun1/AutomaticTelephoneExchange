using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilingSystem
{
    class CallHistory
    {
        public IList<CallRecord> CallRecords { get; private set; }
        public CallHistory()
        {
            CallRecords = new List<CallRecord>();
        }
        public void AddRecordOfReport(CallRecord record)
        {
            CallRecords.Add(record);
        }
        public IList<CallRecord> GetRecords()
        {
            return CallRecords;
        }
    }
}
