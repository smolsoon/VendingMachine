using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class CoinService : ICoinService
    {
        private readonly Dictionary<CoinType, int> _coinsAvailable;

        public CoinService(Dictionary<CoinType, int> initialCoinsAvailable)
        {
            _coinsAvailable = initialCoinsAvailable;
        }

        public Dictionary<CoinType, int> CalculateChange(decimal costOfSelectedItem, decimal totalOfCoinsSupplied)
        {
            var changeAvailableToReturn = new Dictionary<CoinType, int>();
            var coinsAvailableForChange = new Dictionary<CoinType, int>(_coinsAvailable);
            var amountRequiredInChange = totalOfCoinsSupplied - costOfSelectedItem;

            if (amountRequiredInChange > 0)
            {
                CalculateCoins(amountRequiredInChange, coinsAvailableForChange, changeAvailableToReturn, CoinType.Dollar);
            }

            return changeAvailableToReturn;
        }

        private static void CalculateCoins(decimal remainingAmountRequiredInChange, IDictionary<CoinType, int> coinsAvailable, IDictionary<CoinType, int> coinsToReturnInChange, CoinType currentCoinType)
        {
            if (remainingAmountRequiredInChange > 0)
            {
                if ((remainingAmountRequiredInChange >= currentCoinType.Value()))
                {
                    if (coinsToReturnInChange.ContainsKey(currentCoinType))
                    {
                        coinsToReturnInChange[currentCoinType] += 1;
                    }
                    else
                    {
                        coinsToReturnInChange.Add(currentCoinType, 1);
                    }
                    coinsAvailable[currentCoinType] -= 1;
                    remainingAmountRequiredInChange -= currentCoinType.Value();
                    CalculateCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, currentCoinType);
                }
                else
                {
                    currentCoinType--;
                    switch (currentCoinType)
                    {
                        case CoinType.Nickel:
                            CalculateCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Nickel);
                            break;
                        case CoinType.Dime:
                            CalculateCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Dime);
                            break;
                        case CoinType.Quartet:
                            CalculateCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Quartet);
                            break;
                        case CoinType.Dollar:
                            CalculateCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Dollar);
                            break;
                    }
                }
            }
        }



        public static void Calculate(Dictionary<CoinType,int> returnCoin)
        {
            foreach (var item in returnCoin)
            {
                Console.WriteLine(item);
            }
        }
    }
}