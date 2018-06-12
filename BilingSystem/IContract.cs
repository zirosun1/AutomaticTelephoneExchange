using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
    public interface IContract
    {
        Client Client { get; }
        int Number { get; }
        Tariff Tariff { get; }
        bool ChangeTariff(TypeOfTariff tariffType);
    }
}
