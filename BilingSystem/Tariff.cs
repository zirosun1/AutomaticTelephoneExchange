using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
   public class Tariff
    {
        public int MonthlyPayment { get; private set; }
        public int PricePerMinute { get; private set; }
        public int LimitСallsPerMonth { get; private set; }
        public TypeOfTariff TariffType { get; private set; }
        public Tariff(TypeOfTariff type)
        {
            TariffType = type;
            switch (TariffType)
            {
                case TypeOfTariff.Mini:
                    {
                        MonthlyPayment = 10;
                        PricePerMinute = 1;
                        LimitСallsPerMonth = 3;
                        break;
                    }
                case TypeOfTariff.Midi:
                    {
                        MonthlyPayment = 15;
                        PricePerMinute = 1;
                        LimitСallsPerMonth = 5;
                        break;
                    }
                case TypeOfTariff.Maxi:
                    {
                        MonthlyPayment = 20;
                        PricePerMinute = 2;
                        LimitСallsPerMonth = 8;
                        break;
                    }
                default:
                    {
                        MonthlyPayment = 0;
                        PricePerMinute = 0;
                        LimitСallsPerMonth = 0;
                        break;
                    }
            }
        }
    }
}
