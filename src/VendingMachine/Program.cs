using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine {
    class Program {
        static void Main (string[] args) {

            var initialCoinLoad = new Dictionary<CoinType, int> {
                    { CoinType.Dollar, 0 },
                    { CoinType.Quartet, 0 },
                    { CoinType.Dime, 0 },
                    { CoinType.Nickel, 0 },
                };

            var machine = new CoinService (initialCoinLoad);

            Dictionary<CoinType,int> returnCoin = new Dictionary<CoinType, int>();
            decimal sum = 0;
            bool chooseProduct = false;
            while (!chooseProduct) {
                Console.WriteLine ("Add money:\n 1. Nickel,\n 2. Dime,\n 3. Quartet,\n 4. Dollar\n 5. Choose product: \n ");
                int insert = int.Parse (Console.ReadLine ());
                decimal i = 0;
                switch (insert) {
                    case 1:
                        i = i + CoinType.Nickel.Value ();
                        sum = sum + i;
                        break;
                    case 2:
                        i = i + CoinType.Dime.Value ();
                        sum = sum + i;
                        break;
                    case 3:
                        i = i + CoinType.Quartet.Value ();
                        sum = sum + i;
                        break;
                    case 4:
                        i = i + CoinType.Dollar.Value ();
                        sum = sum + i;
                        break;
                    case 5:
                        chooseProduct = true;
                        break;
                    default:
                        break;
                }

                Console.WriteLine ("Suma = " + sum);
            }

            bool exit = false;

            while (!exit) {

                Console.WriteLine ("Choose product:\n 1. Item A,\n 2. Item B,\n 3. Item C ");
                System.Console.WriteLine($"You have {sum}");
                int insert = int.Parse (Console.ReadLine ());

                 switch (insert) {
                    case 1:
                         ChooseItemA(sum, machine);
                         exit = true;
                        break;
                    case 2:
                        ChooseItemB(sum, machine);
                        exit = true;
                        break;
                    case 3:
                        ChooseItemC(sum, machine);
                        exit = true;
                        break;

                    case 4:
                        exit = true;
                        break;
                    default:
                     Console.WriteLine ("You have not money enaugh");
                    break;
                }
            }
        }

        static string ConvertChangeToString (Dictionary<CoinType, int> change) {
            return change.Sum (amount => amount.Key.Value () * amount.Value).ToString ("c");
        }

        static void ChooseItemA(decimal sum, CoinService machine)
        {
            if (sum >= ItemType.ItemA.Value ()) 
            {
                var itemAmount = ItemType.ItemA;
                decimal moneyInserted = sum;
                var amount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value (), moneyInserted));
                var changeAmount = machine.CalculateChange(itemAmount.Value (), moneyInserted);
                Console.WriteLine ($"I've bought a {itemAmount} for {itemAmount.Value()} and got {amount} in change from my {moneyInserted}.");
                foreach (var item in changeAmount)
                {
                    Console.WriteLine(item.Value + " - " + item.Key);
                }
            }
        }

        static void ChooseItemB(decimal sum, CoinService machine)
        {
            if (sum >= ItemType.ItemB.Value ()) 
            {
                var itemAmount = ItemType.ItemB;
                decimal moneyInserted = sum;
                var amount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value (), moneyInserted));
                var changeAmount = machine.CalculateChange(itemAmount.Value (), moneyInserted);
                Console.WriteLine ($"I've bought a {itemAmount} for {itemAmount.Value()} and got {amount} in change from my {moneyInserted}.");
                foreach (var item in changeAmount)
                {
                    Console.WriteLine(item.Value + " - " + item.Key);
                }
            }
        }

        static void ChooseItemC(decimal sum, CoinService machine)
        {
            if (sum >= ItemType.ItemC.Value ()) 
            {
                var itemAmount = ItemType.ItemC;
                decimal moneyInserted = sum;
                var amount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value (), moneyInserted));
                var changeAmount = machine.CalculateChange(itemAmount.Value (), moneyInserted);
                Console.WriteLine ($"I've bought a {itemAmount} for {itemAmount.Value()} and got {amount} in change from my {moneyInserted}.");
                foreach (var item in changeAmount)
                {
                    Console.WriteLine(item.Value + " - " + item.Key);
                }
            }
        }
    }
}