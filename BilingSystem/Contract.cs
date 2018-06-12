using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilingSystem.Enums;

namespace BilingSystem
{
  public  class Contract : IContract
    {
            public Client Client { get; private set; }
            public int Number { get; private set; }
            public Tariff Tariff { get; set; }
            private DateTime TariffEffectiveDate { get; set; }
            static Random rnd = new Random();

            public Contract(Client client, TypeOfTariff typeOfTariff)
            {
                TariffEffectiveDate = DateTime.Now;
                Client = client;
                Number = rnd.Next(1000, 9999);
                Tariff = new Tariff(typeOfTariff);
            }
            public bool ChangeTariff(TypeOfTariff typeOfTariff)
            {
                if (DateTime.Now.AddMonths(-1) >= TariffEffectiveDate)
                {
                    TariffEffectiveDate = DateTime.Now;
                    Tariff = new Tariff(typeOfTariff);
                    //Console.WriteLine("Tariff has been changed");
                    return true;
                }
                else
                {
                    //Console.WriteLine("To change the tariff, wait until the end of the month");
                    return false;
                }
            }

        }
}
