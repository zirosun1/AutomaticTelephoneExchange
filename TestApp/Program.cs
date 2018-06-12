using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BilingSystem;
using BilingSystem.Enums;
using AutomaticTelephoneExchange.Classes;
using AutomaticTelephoneExchange.Interfaces;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IATE ate = new ATE();
            CallHandler handler = new CallHandler();
            IBillingSystem bs = new BillingSystem(ate);

            IContract c1 = ate.SignContract(new Client("Vasya", "Topolev"), TypeOfTariff.Mini);
            IContract c2 = ate.SignContract(new Client("Petya", "Sosnov"), TypeOfTariff.Maxi);
            IContract c3 = ate.SignContract(new Client("Gena", "Beresov"), TypeOfTariff.Mini);

            c1.Client.PutMoney(5000);
            c1.Client.WithdrawMoney(30);
            Terminal t1 = ate.NewTerminal(c1);
            Terminal t2 = ate.NewTerminal(c2);
            Terminal t3 = ate.NewTerminal(c3);
            t1.ConnectToATS();
            t2.ConnectToATS();
            t3.ConnectToATS();
            t1.Call(t2.Number);
            Thread.Sleep(1111);
            t2.EndCall();
            t3.Call(t1.Number);
            Thread.Sleep(2222);
            t3.EndCall();
            t2.Call(t1.Number);
            Thread.Sleep(3333);
            t1.EndCall();
            Console.ReadKey();
        }
    }
}
