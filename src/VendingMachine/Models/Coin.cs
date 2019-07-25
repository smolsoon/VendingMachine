namespace VendingMachine.Models
{
    public static class Coin
    {
        public static decimal Value(this CoinType type)
        {
            switch (type)
            {
                case CoinType.Nickel:
                    return 0.05M;
                case CoinType.Dime:
                    return 0.10M;
                case CoinType.Quartet:
                    return 0.25M;
                case CoinType.Dollar:
                    return 1M;
                default:
                    return 0.00M;
            }
        }
    }
}