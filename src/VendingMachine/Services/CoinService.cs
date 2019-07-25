using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class CoinService
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
                CalculateChangeCoins(amountRequiredInChange, coinsAvailableForChange, changeAvailableToReturn, CoinType.Dollar);
            }

            return changeAvailableToReturn;
        }

        private static void CalculateChangeCoins(decimal remainingAmountRequiredInChange, IDictionary<CoinType, int> coinsAvailable, IDictionary<CoinType, int> coinsToReturnInChange, CoinType currentCoinType)
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
                    CalculateChangeCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, currentCoinType);
                }
                else
                {
                    currentCoinType--;
                    switch (currentCoinType)
                    {
                        case CoinType.Nickel:
                            CalculateChangeCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Nickel);
                            break;
                        case CoinType.Dime:
                            CalculateChangeCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Dime);
                            break;
                        case CoinType.Quartet:
                            CalculateChangeCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Quartet);
                            break;
                        case CoinType.Dollar:
                            CalculateChangeCoins(remainingAmountRequiredInChange, coinsAvailable, coinsToReturnInChange, CoinType.Dollar);
                            break;
                    }
                }
            }
        }
    }
}