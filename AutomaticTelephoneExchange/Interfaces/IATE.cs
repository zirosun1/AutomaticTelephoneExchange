using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticTelephoneExchange.Classes;
using BilingSystem;
using BilingSystem.Enums;

namespace AutomaticTelephoneExchange.Interfaces
{
    public interface IATE : IData<CallInfo>
    {
        Terminal NewTerminal(IContract contract);
        IContract SignContract(Client client, TypeOfTariff typeOfTariff);
        void Calling(object sender, ICallEventArgs e);
    }
}
