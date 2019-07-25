using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface ICoinService
    {
        Dictionary<CoinType, int> CalculateChange(decimal costOfSelectedItem, decimal totalOfCoinsSupplied);
    }
}