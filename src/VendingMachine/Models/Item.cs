namespace VendingMachine.Models
{
    public static class Item
    {
        public static decimal Value(this ItemType type)
        {
            switch (type)
            {
                case ItemType.ItemA:
                    return 0.65M;
                case ItemType.ItemB:
                    return 1M;
                case ItemType.ItemC:
                    return 1.5M;
                default:
                    return 0.00M;
            }
        }
    }
}