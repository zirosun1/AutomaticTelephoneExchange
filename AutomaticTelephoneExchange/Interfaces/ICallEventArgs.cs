﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTelephoneExchange.Interfaces
{
  public  interface ICallEventArgs
    {
        int Number { get; }
        int TargetNumber { get; }
        Guid Id { get; }
    }
}
