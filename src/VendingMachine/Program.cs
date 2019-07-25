using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialCoinLoad = new Dictionary<CoinType, int>
                {
                    {CoinType.Dollar, 1},
                    {CoinType.Quartet, 2},
                    {CoinType.Dime, 2},
                    {CoinType.Nickel, 2},
                };

            var machine = new CoinService(initialCoinLoad);
            decimal sum = 0;
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Add money:\n 1 Nickel,\n 2 Dime,\n 3 Quartet,\n 4 Dollar\n 5. Exit\n ");
                int insert = int.Parse(Console.ReadLine());
                decimal i = 0;
                switch(insert)
                {
                    case 1:
                        i = i + CoinType.Nickel.Value();
                        sum = sum + i;
                        break;
                    case 2:
                        i = i + CoinType.Dime.Value();
                        sum = sum + i;          
                        break;
                    case 3:
                        i =i + CoinType.Quartet.Value();
                        sum = sum + i;                        
                        break;
                    case 4:
                        i =i +  CoinType.Dollar.Value();
                        sum = sum + i;                        
                        break;
                    case 5: 
                        exit = true;
                        Console.WriteLine("Suma:" + sum);
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Suma = " + sum );
            }

            if(sum >= ItemType.ItemA.Value())
            {
                var itemAmount = ItemType.ItemA;
                decimal moneyInserted = sum;
                var changeAmount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value(), moneyInserted));
                Console.WriteLine($"I've bought a {itemAmount} for {itemAmount.Value()} and got {changeAmount} in change from my {moneyInserted}.");
            }
            if(sum >= ItemType.ItemB.Value())
            {
                var itemAmount = ItemType.ItemB;
                decimal moneyInserted = sum;
                var changeAmount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value(), moneyInserted));
                Console.WriteLine($"I've bought a {itemAmount} for {itemAmount.Value()} and got {changeAmount} in change from my {moneyInserted}.");
            }
            if(sum >= ItemType.ItemC.Value())
            {
                var itemAmount = ItemType.ItemC;
                decimal moneyInserted = sum;
                var changeAmount = ConvertChangeToString(machine.CalculateChange(itemAmount.Value(), moneyInserted));
                Console.WriteLine($"I've bought a {itemAmount} for {itemAmount.Value()} and got {changeAmount} in change from my {moneyInserted}.");
            }
            else
            {
                Console.WriteLine("You have not money enaugh");
            }
        }

        static string ConvertChangeToString(Dictionary<CoinType, int> change)
        {
            return change.Sum(amount => amount.Key.Value()*amount.Value).ToString("c");
        }
    }
}
