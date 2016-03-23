using Items;

namespace Consumer
{
    class ItemProcessorFactory
    {
        public static IItemProcessor Build(object item)
        {
            if (item.GetType() == typeof(Item1))
            {
                return new Item1Processor((Item1)item);
            }

            if (item.GetType() == typeof(Item2))
            {
                return new Item2Processor((Item2)item);
            }

            return null;
        }
    }
}
