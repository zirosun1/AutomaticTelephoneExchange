using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
    class Contract : IContract
    {
        public Client Client => throw new NotImplementedException();

        public int Number => throw new NotImplementedException();

        public Tariff Tariff => throw new NotImplementedException();

        public bool ChangeTariff(TypeOfTariff tariffType)
        {
            throw new NotImplementedException();
        }
    }
}
